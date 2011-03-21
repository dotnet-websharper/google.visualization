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


[<JavaScriptType>]
type TreeMapOptions [<Inline "{}">] () =
    /// The color of the header section for each node. Specify an HTML color value.
    [<DefaultValue>]
    val mutable headerColor: string
    /// The height of the header section for each node, in pixels (can be zero).
    [<DefaultValue>]
    val mutable headerHeight: int
    /// The color of the header of a node being hovered over. Specify an HTML color value, null, or 'auto; if null or 'auto', this value will be headerColor lightened by 35%
    [<DefaultValue>]
    val mutable headerHighlightColor: string
    /// The color for a rectangle with a column 3 value of maxColorValue. Specify an HTML color value.
    [<DefaultValue>]
    val mutable maxColor: string
    /// The maximum number of node levels to show in the current view. Levels will be flattened into the current plane. If your tree has more levels than this, you will have to go up or down to see them. You can additionally see maxPostDepth levels below this as shaded rectangles within these nodes.
    [<DefaultValue>]
    val mutable maxDepth: int
    /// The highlight color to use for the node with the largest value in column 3. Specify an HTML color value, null, or 'auto. If null or 'auto', this value will be the value of maxColor lightened by 35%
    [<DefaultValue>]
    val mutable maxHighlightColor: string
    /// How many levels of nodes beyond maxDepth to show in "hinted" fashion. Hinted nodes are shown as shaded rectangles within a node that is within the maxDepth limit.
    [<DefaultValue>]
    val mutable maxPostDepth: int
    /// The maximum value allowed in column 3. All values greater than this will be trimmed to this value. If set to null or 'auto', it will be set to the max value in the column.
    [<DefaultValue>]
    val mutable maxColorValue: int
    /// The color for a rectangle with a column 3 value midway between maxColorValue and minColorValue. Specify an HTML color value.
    [<DefaultValue>]
    val mutable midColor: string
    /// The highlight color to use for the node with a column 3 value near the median of minColorValue and maxColorValue. Specify an HTML color value or 'auto'. If null or 'auto', this value will be the value of midColor lightened by 35%.
    [<DefaultValue>]
    val mutable midHighlightColor: string
    /// The color for a rectangle with the column 3 value of minColorValue. Specify an HTML color value.
    [<DefaultValue>]
    val mutable minColor: string
    /// The highlight color to use for the node with a column 3 value nearest to minColorValue. Specify an HTML color value or 'auto'. If null or 'auto', this value will be the value of minColor lightened by 35%
    [<DefaultValue>]
    val mutable minHighlightColor: string
    /// The minimum value allowed in column 3. All values less than this will be trimmed to this value. If set to null or 'auto', it will be calculated as the minimum value in the column.
    [<DefaultValue>]
    val mutable minColorValue: int
    /// The color to use for a rectangle when a node has no value for column 3, and that node is a leaf (or contains only leaves). Specify an HTML color value.
    [<DefaultValue>]
    val mutable noColor: string
    /// The color to use for a rectangle of "no" color when highlighted. This will be the value of noColor lightened by 35%. Specify an HTML value.
    [<DefaultValue>]
    val mutable noHighlightColor: string
    /// Whether or not to show a color gradient scale from minColor to maxColor along the top of the chart. Specify true to show the scale.
    [<DefaultValue>]
    val mutable showScale: bool
    /// Whether or not to show tooltips.
    [<DefaultValue>]
    val mutable showTooltips: bool
    /// The text color. Specify an HTML color value.
    [<DefaultValue>]
    val mutable fontColor: string
    /// The font family to use for all text.
    [<DefaultValue>]
    val mutable fontFamily: string
    /// The font size for all text, in points.
    [<DefaultValue>]
    val mutable fontSize: float


//
//[<JavaScriptType>]
//type TreeMapOptions = {
//    /// The color of the header section for each node. Specify an HTML color value.
//    headerColor: string
//    /// The height of the header section for each node, in pixels (can be zero).
//    headerHeight: int
//    /// The color of the header of a node being hovered over. Specify an HTML color value, null, or 'auto; if null or 'auto', this value will be headerColor lightened by 35%
//    headerHighlightColor: string
//    /// The color for a rectangle with a column 3 value of maxColorValue. Specify an HTML color value.
//    maxColor: string
//    /// The maximum number of node levels to show in the current view. Levels will be flattened into the current plane. If your tree has more levels than this, you will have to go up or down to see them. You can additionally see maxPostDepth levels below this as shaded rectangles within these nodes.
//    maxDepth: int
//    /// The highlight color to use for the node with the largest value in column 3. Specify an HTML color value, null, or 'auto. If null or 'auto', this value will be the value of maxColor lightened by 35%
//    maxHighlightColor: string
//    /// How many levels of nodes beyond maxDepth to show in "hinted" fashion. Hinted nodes are shown as shaded rectangles within a node that is within the maxDepth limit.
//    maxPostDepth: int
//    /// The maximum value allowed in column 3. All values greater than this will be trimmed to this value. If set to null or 'auto', it will be set to the max value in the column.
//    maxColorValue: int
//    /// The color for a rectangle with a column 3 value midway between maxColorValue and minColorValue. Specify an HTML color value.
//    midColor: string
//    /// The highlight color to use for the node with a column 3 value near the median of minColorValue and maxColorValue. Specify an HTML color value or 'auto'. If null or 'auto', this value will be the value of midColor lightened by 35%.
//    midHighlightColor: string
//    /// The color for a rectangle with the column 3 value of minColorValue. Specify an HTML color value.
//    minColor: string
//    /// The highlight color to use for the node with a column 3 value nearest to minColorValue. Specify an HTML color value or 'auto'. If null or 'auto', this value will be the value of minColor lightened by 35%
//    minHighlightColor: string
//    /// The minimum value allowed in column 3. All values less than this will be trimmed to this value. If set to null or 'auto', it will be calculated as the minimum value in the column.
//    minColorValue: int
//    /// The color to use for a rectangle when a node has no value for column 3, and that node is a leaf (or contains only leaves). Specify an HTML color value.
//    noColor: string
//    /// The color to use for a rectangle of "no" color when highlighted. This will be the value of noColor lightened by 35%. Specify an HTML value.
//    noHighlightColor: string
//    /// Whether or not to show a color gradient scale from minColor to maxColor along the top of the chart. Specify true to show the scale.
//    showScale: bool
//    /// Whether or not to show tooltips.
//    showTooltips: bool
//    /// The text color. Specify an HTML color value.
//    fontColor: string
//    /// The font family to use for all text.
//    fontFamily: string
//    /// The font size for all text, in points.
//    fontSize: float    
//} with
//    [<JavaScript>]
//    static member Default : TreeMapOptions = Empty<TreeMapOptions>

/// A geomap is a map of a country, continent, or region map, with colors and values 
/// assigned to specific regions. Values are displayed as a color scale, and you can
/// specify optional hovertext for regions. The map is rendered in the browser using
/// an embedded Flash player. Note that the map is not scrollable or draggable, but 
/// can be configured to allow zooming.
[<Stub>]
[<Name "google.visualization.TreeMap">]
[<Require(typeof<Dependencies.TreeMap>)>]
type TreeMap =
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    member this.draw(data: DataCommon, options: TreeMapOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    member this.getSelection() : obj = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    member this.setSelection(selection: obj) : unit = X

    /// Move up the tree by one level and redraw it. Does not throw an 
    /// error if the node is the root node. This is fired automatically 
    /// when the user right-clicks a node.
    member this.goUpAndDraw() : unit = X

    /// Returns the maximum possible depth for the current view.
    member this.getMaxPossibleDepth() : unit = X