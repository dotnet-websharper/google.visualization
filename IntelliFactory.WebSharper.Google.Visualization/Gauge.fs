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

type GaugeOptions = {

    /// The lowest value for a range marked by a green color.
    ///
    /// Default Value: none
    greenFrom : float
     
    /// The highest value for a range marked by a green color.
    ///
    /// Default Value: none
    greenTo : float
     
    /// Height of the chart in pixels.
    /// Default Value: Container's width
    height : float
     
    /// Labels for major tick marks. The number of labels define the number of
    /// major ticks in all gauges. The default is five major ticks, with the
    /// labels of the minimal and maximal gauge value.
    ///
    /// Default Value: none
    majorTicks : string []
     
    /// The maximal value of a gauge.
    ///
    /// Default Value: 100
    max : float
     
    /// The minimal value of a gauge.
    ///
    /// Default Value: 0
    min : float
     
    /// The number of minor tick section in each major tick section.
    ///
    /// Default Value: 2
    minorTicks : float
     
    /// The lowest value for a range marked by a red color.
    ///
    /// Default Value: none
    redFrom : float
     
    /// The highest value for a range marked by a red color.
    ///
    /// Default Value: none
    redTo : float
     
    /// Width of the chart in pixels.
    /// Default Value: Container's width
    width : float
     
    /// The lowest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    yellowFrom : float
     
    /// The highest value for a range marked by a yellow color.
    ///
    /// Default Value: none
    yellowTo : float
} with
    [<JavaScript>]
    static member Default : GaugeOptions = Empty<GaugeOptions>


/// One or more gauges are rendered within the browser using SVG or VML. 
[<Stub>]
[<Name "google.visualization.Gauge">]
[<Require(typeof<Dependencies.Gauge>)>]
type Gauge =
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    member this.draw(data: DataCommon, options: GaugeOptions) : unit = X
