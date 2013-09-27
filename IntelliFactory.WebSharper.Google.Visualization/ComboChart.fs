// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base

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
