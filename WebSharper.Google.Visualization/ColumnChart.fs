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

namespace WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open WebSharper
open WebSharper.JavaScript
open WebSharper.Google.Visualization
open WebSharper.Google.Visualization.Base

type ColumnChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable bar : Bar

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    [<DefaultValue>]
    val mutable isStacked : bool

    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// A vertical bar chart that is rendered within the browser using SVG or VML. 
/// Displays tips when clicking on points. Animates lines when clicking on legend
/// entries. For a horizontal version of this chart, see the Bar Chart.
[<Name "google.visualization.ColumnChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type ColumnChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<ColumnChartOptions> ()
