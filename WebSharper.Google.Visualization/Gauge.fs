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

type GaugeOptions [<Inline "{}">] () =

    /// The lowest value for a range marked by a green color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable greenFrom : float
     
    /// The highest value for a range marked by a green color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable greenTo : float
     
    /// Height of the chart in pixels.
    /// Default Value: Container's width
    [<DefaultValue>]
    val mutable height : float
     
    /// Labels for major tick marks. The number of labels define the number of
    /// major ticks in all gauges. The default is five major ticks, with the
    /// labels of the minimal and maximal gauge value.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable majorTicks : string []
     
    /// The maximal value of a gauge.
    ///
    /// Default Value: 100
    [<DefaultValue>]
    val mutable max : float
     
    /// The minimal value of a gauge.
    ///
    /// Default Value: 0
    [<DefaultValue>]
    val mutable min : float
     
    /// The number of minor tick section in each major tick section.
    ///
    /// Default Value: 2
    [<DefaultValue>]
    val mutable minorTicks : float
     
    /// The lowest value for a range marked by a red color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable redFrom : float
     
    /// The highest value for a range marked by a red color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable redTo : float
     
    /// Width of the chart in pixels.
    /// Default Value: Container's width
    [<DefaultValue>]
    val mutable width : float
     
    /// The lowest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable yellowFrom : float
     
    /// The highest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    [<DefaultValue>]
    val mutable yellowTo : float


/// One or more gauges are rendered within the browser using SVG or VML. 
[<Name "google.visualization.Gauge">]
[<Require(typeof<Dependencies.Gauge>)>]
type Gauge [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<GaugeOptions> ()
