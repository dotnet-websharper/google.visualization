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

type Bar [<Inline "{}">] () =
    /// The width of a group of bars, specified in either of these formats:
    ///     * Pixels (e.g. 50).
    ///     * Percentage of the available width for each group (e.g. '20%'),
    ///       where '100%' means that groups have no space between them.
    [<DefaultValue>]
    val mutable groupWidth : string

type BarChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable bar : Bar

    [<DefaultValue>]
    val mutable hAxes : Axis[]

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    [<DefaultValue>]
    val mutable isStacked : bool

/// A horizontal bar chart that is rendered within the browser using 
/// SVG or VML. Displays tips when clicking on points. Animates lines
/// when clicking on legend entries. For a vertical version of this 
/// chart, see the Column Chart.
[<Name "google.visualization.BarChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type BarChart [<Stub>] (e: Dom.Element) =
    inherit ChartCommon<BarChartOptions>()
