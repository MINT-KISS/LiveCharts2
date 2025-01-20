// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel;
using LiveChartsCore.Measure;
using LiveChartsCore.Painting;

namespace LiveChartsCore.VisualElements;

/// <summary>
/// Defines a visual element in a chart that draws a sized geometry in the user interface.
/// </summary>
/// <typeparam name="TGeometry">The type of the geometry.</typeparam>
/// <typeparam name="TLabelGeometry">The type of the label.</typeparam>
public class GeometryVisual<TGeometry, TLabelGeometry> : BaseGeometryVisual
    where TGeometry : BoundedDrawnGeometry, new()
    where TLabelGeometry : BaseLabelGeometry, new()
{
    internal TGeometry? _geometry;
    private string _label = string.Empty;
    private float _labelSize = 12;
    internal TLabelGeometry? _labelGeometry;
    private Paint? _labelPaint = null;
    private float _labelPadding = 0;
    private Align _labelVerticalAlign = Align.Middle;
    private Align _labelHorizontalAlign = Align.Middle;

    /// <summary>
    /// Gets or sets the label, a string to be displayed within the section.
    /// </summary>
    public string Label { get => _label; set => SetProperty(ref _label, value); }

    /// <summary>
    /// Gets or sets the label size.
    /// </summary>
    public double LabelSize { get => _labelSize; set => SetProperty(ref _labelSize, (float)value); }

    /// <summary>
    /// Gets or sets the SVG path.
    /// </summary>
    public string? Svg { get; set; }

    /// <summary>
    /// Gets or sets the label paint.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public Paint? LabelPaint
    {
        get => _labelPaint;
        set => SetPaintProperty(ref _labelPaint, value);
    }

    /// <summary>
    /// Gets or sets the label padding.
    /// </summary>
    public float LabelPadding { get => _labelPadding; set => SetProperty(ref _labelPadding, value); }

    /// <summary>
    /// Gets or sets the label vertical align.
    /// </summary>
    public Align LabelVerticalAlign { get => _labelVerticalAlign; set => SetProperty(ref _labelVerticalAlign, value); }

    /// <summary>
    /// Gets or sets the label horizontal align.
    /// </summary>
    public Align LabelHorizontalAlign { get => _labelHorizontalAlign; set => SetProperty(ref _labelHorizontalAlign, value); }

    /// <inheritdoc cref="ChartElement.GetPaintTasks"/>
    protected internal override Animatable?[] GetDrawnGeometries() =>
        [_geometry, _labelGeometry];

    /// <inheritdoc cref="VisualElement.OnInvalidated(Chart)"/>
    protected internal override void OnInvalidated(Chart chart)
    {
        var l = GetActualCoordinate();
        var size = Measure(chart);
        var clipping = Clipping.GetClipRectangle(ClippingMode, chart);

        OnSizeChanged?.Invoke(size);

        if (_geometry is null)
        {
            _geometry = new()
            {
                X = l.X,
                Y = l.Y,
                Width = size.Width,
                Height = size.Height,
                RotateTransform = (float)Rotation
            };

            if (Svg is not null)
            {
                var svgGeometry = _geometry as IVariableSvgPath
                    ?? throw new Exception($"The geometry must be of type {nameof(IVariableSvgPath)}.");

                svgGeometry.SVGPath = Svg;
            }

            _geometry.Animate(chart);
        }

        _geometry.X = l.X;
        _geometry.Y = l.Y;
        _geometry.Width = size.Width;
        _geometry.Height = size.Height;
        _geometry.RotateTransform = (float)Rotation;
        _geometry.TranslateTransform = Translate;

        if (Fill is not null)
        {
            chart.Canvas.AddDrawableTask(Fill);
            Fill.AddGeometryToPaintTask(chart.Canvas, _geometry);
            Fill.SetClipRectangle(chart.Canvas, clipping);
        }

        if (Stroke is not null)
        {
            chart.Canvas.AddDrawableTask(Stroke);
            Stroke.AddGeometryToPaintTask(chart.Canvas, _geometry);
            Stroke.SetClipRectangle(chart.Canvas, clipping);
        }

        if (LabelPaint is not null)
        {
            var xLabel = l.X + size.Width / 2;
            var yLabel = l.Y + size.Height / 2;

            switch (_labelHorizontalAlign)
            {
                case Align.Start:
                    xLabel = l.X + _labelPadding;
                    break;
                case Align.End:
                    xLabel = l.X + size.Width - _labelPadding;
                    break;
                case Align.Middle:
                default:
                    break;
            };

            switch (_labelVerticalAlign)
            {
                case Align.Start:
                    yLabel = l.Y + _labelPadding;
                    break;
                case Align.End:
                    yLabel = l.Y + size.Height - _labelPadding;
                    break;
                case Align.Middle:
                default:
                    break;
            };

            if (_labelGeometry is null)
            {
                _labelGeometry = new TLabelGeometry
                {
                    X = xLabel,
                    Y = yLabel
                };

                _labelGeometry.Animate(
                    chart,
                    nameof(_labelGeometry.X), nameof(_labelGeometry.Y), nameof(_labelGeometry.Opacity));
                _labelGeometry.VerticalAlign = _labelVerticalAlign;
                _labelGeometry.HorizontalAlign = _labelHorizontalAlign;
            }

            _labelGeometry.X = xLabel;
            _labelGeometry.Y = yLabel;
            _labelGeometry.Text = _label;
            _labelGeometry.TextSize = _labelSize;
            _labelGeometry.RotateTransform = (float)Rotation;
            _labelGeometry.TranslateTransform = Translate;
            _labelGeometry.Paint = LabelPaint;

            chart.Canvas.AddDrawableTask(LabelPaint);
            LabelPaint.AddGeometryToPaintTask(chart.Canvas, _labelGeometry);
            LabelPaint.SetClipRectangle(chart.Canvas, clipping);
        }
    }

    /// <inheritdoc cref="VisualElement.SetParent(DrawnGeometry)"/>
    protected internal override void SetParent(DrawnGeometry parent)
    {
        if (_geometry is null) return;
        ((IDrawnElement)_geometry).Parent = parent;
    }

    /// <inheritdoc cref="VisualElement.Measure(Chart)"/>
    public override LvcSize Measure(Chart chart)
    {
        var w = (float)Width;
        var h = (float)Height;

        if (SizeUnit == MeasureUnit.ChartValues)
        {
            if (PrimaryScaler is null || SecondaryScaler is null)
                throw new Exception($"You can not use {MeasureUnit.ChartValues} scale at this element.");

            w = SecondaryScaler.MeasureInPixels(w);
            h = PrimaryScaler.MeasureInPixels(h);
        }

        return new LvcSize(w, h);
    }

    /// <inheritdoc cref="ChartElement.GetPaintTasks"/>
    protected internal override Paint?[] GetPaintTasks() =>
        [Fill, Stroke, _labelPaint];

    /// <summary>
    /// Called when the element size is changed
    /// </summary>
    public event Action<LvcSize>? OnSizeChanged;
}
