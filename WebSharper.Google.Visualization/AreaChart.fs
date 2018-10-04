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

type AreaChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    /// The default opacity of the colored area under an area chart
    /// series, where 0.0 is fully transparent and 1.0 is fully
    /// opaque. To specify opacity for an individual series, set the
    /// areaOpacity value in the series property.
    [<DefaultValue>]
    val mutable areaOpacity : float

    /// If set to true, line values are stacked (accumulated).
    /// Default Value: false
    [<DefaultValue>]
    val mutable isStacked : bool

    /// Line width in pixels. Use zero to hide all lines and show only the points.
    /// Default Value: 2
    [<DefaultValue>]
    val mutable lineWidth : float
    
    /// Size of displayed points in pixels. Use zero to hide all points.
    /// Default Value: 3
    [<DefaultValue>]
    val mutable pointSize : float

    /// Specifies properties for individual vertical axes, if the
    /// chart has multiple vertical axes. Each child object is a vAxis
    /// object, and can contain all the properties supported by vAxis.
    [<DefaultValue>]
    val mutable vAxes : Axis[]

/// An area chart that is rendered within the browser using SVG or VML. 
/// Displays tips when clicking on points. Animates lines when clicking 
/// on legend entries. 
[<Name "google.visualization.AreaChart">]
[<Require(typeof<Dependencies.AreaChart>)>]
type AreaChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<AreaChartOptions>()
