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

type MotionChartOptions [<Inline "{}">] () =

    /// Height of the chart in pixels.
    /// Default Value: 300
    [<DefaultValue>]
    val mutable height : float
     
    /// Width of the chart in pixels.
    /// Default Value: 500
    [<DefaultValue>]
    val mutable width : float
     
    /// An initial display state for the chart. This is a serialized JSON object
    /// that describes zoom level, selected dimensions, selected bubbles/entities,
    /// and other state descriptions. See <a href="#Motion_Chart_initial_state">Setting
    /// Initial State</a> to
    /// learn how to set this.
    /// Default Value: <em>none</em>
    [<DefaultValue>]
    val mutable state : string
     
    /// false hides the list of visible entities.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showSelectListComponent : string
     
    /// false hides the right hand panel.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showSidePanel : string
     
    /// false hides the metric picker for x.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showXMetricPicker : string
     
    /// false hides the metric picker for y.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showYMetricPicker : string
     
    /// false hides the scale picker for x.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showXScalePicker : string
     
    /// false hides the scale picker for y.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showYScalePicker : string
     
    /// false disables the options compartment in the settings panel.
    /// Default Value: true
    [<DefaultValue>]
    val mutable showAdvancedPanel : string


/// A dynamic chart to explore several indicators over time. The chart is rendered within 
/// the browser using Flash.
[<Name "google.visualization.MotionChart">]
[<Require(typeof<Dependencies.JsApi>)>]
[<Require(typeof<Dependencies.MotionChart>)>]
type MotionChart =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: MotionChartOptions) : unit = X

    /// Returns the current state of the motionchart, serialized to a JSON string. To assign
    /// this state to the chart, assign this string to the state option in the draw() method. 
    /// This is often used to specify a custom chart state on startup, instead of using the 
    /// default state.
    [<Stub>]
    member this.getState() : string = X
