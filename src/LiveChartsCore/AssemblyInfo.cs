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

using System.Runtime.CompilerServices;

#if STRONG_NAMED_ASSEMBLIES
using System.Reflection;

[assembly: AssemblyKeyFile("./../../LiveCharts.snk")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView, PublicKey=00240000048000009400000006020000002400005253413100040000010001005963ca3b6abb14457b040b30965b94a370baf7594c42affd60c231e6dac913db45b908b45ee256fa0336da7f40c23f3f7b95501402f60ae3ade484426053eb11ed6a7f46b275a3eca933061467e70da0e2a58854d95547c7fa9e4275a8cdc1a0cfc12788ff9332ed48c47b0ee4dda0927be223429ebcf7096c4d9cf9e6a830d1")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WinForms, PublicKey=00240000048000009400000006020000002400005253413100040000010001005963ca3b6abb14457b040b30965b94a370baf7594c42affd60c231e6dac913db45b908b45ee256fa0336da7f40c23f3f7b95501402f60ae3ade484426053eb11ed6a7f46b275a3eca933061467e70da0e2a58854d95547c7fa9e4275a8cdc1a0cfc12788ff9332ed48c47b0ee4dda0927be223429ebcf7096c4d9cf9e6a830d1")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WPF, PublicKey=00240000048000009400000006020000002400005253413100040000010001005963ca3b6abb14457b040b30965b94a370baf7594c42affd60c231e6dac913db45b908b45ee256fa0336da7f40c23f3f7b95501402f60ae3ade484426053eb11ed6a7f46b275a3eca933061467e70da0e2a58854d95547c7fa9e4275a8cdc1a0cfc12788ff9332ed48c47b0ee4dda0927be223429ebcf7096c4d9cf9e6a830d1")]
[assembly: InternalsVisibleTo("CoreTests, PublicKey=00240000048000009400000006020000002400005253413100040000010001005963ca3b6abb14457b040b30965b94a370baf7594c42affd60c231e6dac913db45b908b45ee256fa0336da7f40c23f3f7b95501402f60ae3ade484426053eb11ed6a7f46b275a3eca933061467e70da0e2a58854d95547c7fa9e4275a8cdc1a0cfc12788ff9332ed48c47b0ee4dda0927be223429ebcf7096c4d9cf9e6a830d1")]

#else

[assembly: InternalsVisibleTo("CoreTests")]
[assembly: InternalsVisibleTo("SnapshotTests")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView")]
[assembly: InternalsVisibleTo("LiveChartsCore.Behaviours")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WinForms")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WPF")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Avalonia")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WinUI")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Uno")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Uno.WinUI")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.XamarinForms")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Eto")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Blazor")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.Maui")]
[assembly: InternalsVisibleTo("LiveChartsCore.Vortice")]

#endif
