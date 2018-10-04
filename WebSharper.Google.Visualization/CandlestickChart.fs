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
