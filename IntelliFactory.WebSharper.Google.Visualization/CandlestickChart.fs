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

type Candlestick [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable hollowIsRising : bool

    [<DefaultValue>]
    val mutable fallingColor : Color

    [<DefaultValue>]
    val mutable risingColor : Color

type CandlestickChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable candlestick : Candlestick

    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// An interactive candlestick chart. A candlestick chart is used to
/// show an opening and closing value overlaid on top of a total
/// variance. Candlestick charts are often used to show stock value
/// behavior. In this chart, items where the opening value is less
/// than the closing value (a gain) are drawn as filled boxes, and
/// items where the opening value is more than the closing value (a
/// loss) are drawn as hollow boxes.
[<Name "google.visualization.CandlestickChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type CandlestickChart [<Stub>] (e : Dom.Element) =
    inherit ChartCommon<CandlestickChartOptions>()
