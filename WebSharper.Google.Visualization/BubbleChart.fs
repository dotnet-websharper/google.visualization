// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

namespace WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open WebSharper
open WebSharper.JavaScript
open WebSharper.Google.Visualization
open WebSharper.Google.Visualization.Base

type ColorAxisLegend [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable position : LegendPosition

    [<DefaultValue>]
    val mutable textStyle : TextStyle

    /// A format string for numeric labels. This is a subset of the
    /// ICU pattern set. For instance, {numberFormat:'.##'} will
    /// display values "10.66", "10.6", and "10.0" for values 10.666,
    /// 10.6, and 10.
    [<DefaultValue>]
    val mutable numberFormat : string

type BubbleColorAxis [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable minValue : float

    [<DefaultValue>]
    val mutable maxValue : float

    [<DefaultValue>]
    val mutable values : float[]

    [<DefaultValue>]
    val mutable legend : ColorAxisLegend

type Bubble [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable opacity : float

    [<DefaultValue>]
    val mutable stroke : string

    [<DefaultValue>]
    val mutable textStyle : TextStyle

type SizeAxis [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable maxSize : float

    [<DefaultValue>]
    val mutable minSize : float

    [<DefaultValue>]
    val mutable maxValue : float

    [<DefaultValue>]
    val mutable minValue : float

type BubbleChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable bubble : Bubble

    [<DefaultValue>]
    val mutable colorAxis : BubbleColorAxis

    [<DefaultValue>]
    val mutable sizeAxis : SizeAxis

    [<DefaultValue>]
    val mutable sortBubblesBySize : bool

/// A bubble chart that is rendered within the browser using SVG or
/// VML. Displays tips when hovering over bubbles. A bubble chart is
/// used to visualize a data set with 2 to 4 dimensions. The first two
/// dimensions are visualized as coordinates, the 3rd as color and the
/// 4th as size.
[<Name "google.visualization.BubbleChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type BubbleChart [<Stub>] (e : Dom.Element) =
    inherit ChartCommon<BubbleChartOptions>()
