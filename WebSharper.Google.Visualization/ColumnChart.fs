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
