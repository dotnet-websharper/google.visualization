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

namespace IntelliFactory.WebSharper.Google.Visualization.Visualizations

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.Google.Visualization.Base.Helpers

type MotionChartOptions = {

    /// Height of the chart in pixels.
    /// Default Value: 300
    height : float
     
    /// Width of the chart in pixels.
    /// Default Value: 500
    width : float
     
    /// An initial display state for the chart. This is a serialized JSON object
    /// that describes zoom level, selected dimensions, selected bubbles/entities,
    /// and other state descriptions. See <a href="#Motion_Chart_initial_state">Setting
    /// Initial State</a> to
    /// learn how to set this.
    /// Default Value: <em>none</em>
    state : string
     
    /// false hides the list of visible entities.
    /// Default Value: true
    showSelectListComponent : string
     
    /// false hides the right hand panel.
    /// Default Value: true
    showSidePanel : string
     
    /// false hides the metric picker for x.
    /// Default Value: true
    showXMetricPicker : string
     
    /// false hides the metric picker for y.
    /// Default Value: true
    showYMetricPicker : string
     
    /// false hides the scale picker for x.
    /// Default Value: true
    showXScalePicker : string
     
    /// false hides the scale picker for y.
    /// Default Value: true
    showYScalePicker : string
     
    /// false disables the options compartment in the settings panel.
    /// Default Value: true
    showAdvancedPanel : string
} with
    [<JavaScript>]
    static member Default : MotionChartOptions = Empty<MotionChartOptions>


/// A dynamic chart to explore several indicators over time. The chart is rendered within 
/// the browser using Flash.
[<Name "google.visualization.MotionChart">]
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
