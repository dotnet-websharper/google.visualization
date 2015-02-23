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

type SteppedAreaChartOptions [<Inline "{}">] () =
    inherit AreaChartOptions()

    [<DefaultValue>]
    val mutable connectSteps : bool

/// A stepped area chart that is rendered within the browser using SVG
/// or VML. Displays tips when hovering over steps.
[<Name "google.visualization.SteppedAreaChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type SteppedAreaChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<SteppedAreaChartOptions> ()
