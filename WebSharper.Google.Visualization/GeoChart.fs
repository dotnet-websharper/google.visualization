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

type GeoChartDisplayMode =
    | [<Constant "auto">] Auto
    | [<Constant "regions">] Regions
    | [<Constant "markers">] Markers

type GeoChartColorAxis [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable minValue : float

    [<DefaultValue>]
    val mutable maxValue : float

    [<DefaultValue>]
    val mutable values : float[]

    [<DefaultValue>]
    val mutable colors : string[]

type MagnifyingGlass [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable enable : bool

    [<DefaultValue>]
    val mutable zoomFactor : float

type GeoChartResolution =
    | [<Constant "countries">] Countries
    | [<Constant "provinces">] Provinces
    | [<Constant "metros">] Metros

type GeoChartOptions [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable backgroundColor : Color

    [<DefaultValue>]
    val mutable colorAxis : GeoChartColorAxis

    [<DefaultValue>]
    val mutable datalessRegionColor : string

    [<DefaultValue>]
    val mutable displayMode : GeoChartDisplayMode

    [<DefaultValue>]
    val mutable enableRegionInteractivity : bool

    [<DefaultValue>]
    val mutable height : int

    [<DefaultValue>]
    val mutable keepAspectRatio : bool

    [<DefaultValue>]
    val mutable legend : Legend

    [<DefaultValue>]
    val mutable region : Region

    [<DefaultValue>]
    val mutable magnifyingGlass : MagnifyingGlass

    [<DefaultValue>]
    val mutable markerOpacity : float

    [<DefaultValue>]
    val mutable resolution : GeoChartResolution

    [<DefaultValue>]
    val mutable sizeAxis : SizeAxis

    [<DefaultValue>]
    val mutable tooltip : Tooltip

    [<DefaultValue>]
    val mutable width : int

[<Name "google.visualization.GeoChart">]
[<Require(typeof<Dependencies.GeoChart>)>]
type GeoChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<GeoChartOptions>()
