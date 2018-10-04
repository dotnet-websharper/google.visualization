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

type SeriesType =
    | [<Constant "line">] Line
    | [<Constant "area">] Area
    | [<Constant "bars">] Bars
    | [<Constant "candlesticks">] Candlesticks
    | [<Constant "steppedArea">] SteppedArea

type ComboChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable areaOpacity : float

    [<DefaultValue>]
    val mutable bar : Bar

    [<DefaultValue>]
    val mutable candlestick : Candlestick

    [<DefaultValue>]
    val mutable curveType : CurveType

    [<DefaultValue>]
    val mutable interpolateNulls : bool

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    [<DefaultValue>]
    val mutable isStacked : bool

    [<DefaultValue>]
    val mutable lineWidth : int

    [<DefaultValue>]
    val mutable pointSize : int

    [<DefaultValue>]
    val mutable seriesType : SeriesType

    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// A chart that lets you render each series as a different marker
/// type from the following list: line, area, bars, candlesticks and
/// stepped area. To assign a default marker type for series, specify
/// the seriesType property. Use the series property to specify
/// properties of each series individually.
[<Name "google.visualization.ComboChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type ComboChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<ComboChartOptions> ()
