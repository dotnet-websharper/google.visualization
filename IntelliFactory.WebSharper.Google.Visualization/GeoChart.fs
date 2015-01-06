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
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base

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
