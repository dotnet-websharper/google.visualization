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
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base

[<RequireQualifiedAccess>]
type CurveType =
    | [<Constant "none">] None
    | [<Constant "function">] Function

type LineChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable curveType : CurveType

    [<DefaultValue>]
    val mutable interpolateNulls : bool

    [<DefaultValue>]
    val mutable lineWidth : int

    [<DefaultValue>]
    val mutable pointSize : int

    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Name "google.visualization.LineChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type LineChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<LineChartOptions> ()
