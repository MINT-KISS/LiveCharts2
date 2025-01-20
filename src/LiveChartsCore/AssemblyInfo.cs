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

#if !DEBUG && NET462
using System.Reflection;

[assembly: AssemblyKeyFile("./../../LiveCharts.snk")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f94958014cdc4850dc560a1ce367627924a654f8cbe02c859ea71d3e676ec66fa7b8433c9520d86f9c161b7d7faaba95011c7c22f847c2fff89d1cbcc4a06d6aa3e05530b58b1bbc24fcb71fb5f83b93d803f595461523ecc7abcf9fdc82b511ad2108f933739d860050f2e72e348fb574185e094c62527361a332eace27e1b5")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WinForms, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f94958014cdc4850dc560a1ce367627924a654f8cbe02c859ea71d3e676ec66fa7b8433c9520d86f9c161b7d7faaba95011c7c22f847c2fff89d1cbcc4a06d6aa3e05530b58b1bbc24fcb71fb5f83b93d803f595461523ecc7abcf9fdc82b511ad2108f933739d860050f2e72e348fb574185e094c62527361a332eace27e1b5")]
[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView.WPF, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f94958014cdc4850dc560a1ce367627924a654f8cbe02c859ea71d3e676ec66fa7b8433c9520d86f9c161b7d7faaba95011c7c22f847c2fff89d1cbcc4a06d6aa3e05530b58b1bbc24fcb71fb5f83b93d803f595461523ecc7abcf9fdc82b511ad2108f933739d860050f2e72e348fb574185e094c62527361a332eace27e1b5")]

#else

[assembly: InternalsVisibleTo("LiveChartsCore.SkiaSharpView")]
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
[assembly: InternalsVisibleTo("LiveChartsCore.BackersPackage")]
[assembly: InternalsVisibleTo("LiveChartsCore.UnitTesting")]

#endif
