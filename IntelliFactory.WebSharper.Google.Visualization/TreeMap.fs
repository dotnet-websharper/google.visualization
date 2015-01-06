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

type TreeMapOptions [<Inline "{}">] () =
    /// The text color. Specify an HTML color value.
    [<DefaultValue>]
    val mutable fontColor: string
    /// The font family to use for all text.
    [<DefaultValue>]
    val mutable fontFamily: string
    /// The font size for all text, in points.
    [<DefaultValue>]
    val mutable fontSize: float
    /// The color of the header section for each node. Specify an HTML color value.
    [<DefaultValue>]
    val mutable headerColor: string
    /// The height of the header section for each node, in pixels (can be zero).
    [<DefaultValue>]
    val mutable headerHeight: int
    /// The color of the header of a node being hovered over. Specify an HTML color value, null, or 'auto; if null or 'auto', this value will be headerColor lightened by 35%
    [<DefaultValue>]
    val mutable headerHighlightColor: string
    /// When maxPostDepth is greater than 1, causing nodes below the current depth to be shown, hintOpacity specifies how transparent it should be. It should be between 0 and 1; the higher the value, the fainter the node.
    [<DefaultValue>]
    val mutable hintOpacity : float
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
    [<DefaultValue>]
    val mutable textStyle : TextStyle
    [<DefaultValue>]
    val mutable title : string
    [<DefaultValue>]
    val mutable titleTextStyle : TextStyle
    [<DefaultValue>]
    val mutable useWeightedAverageForAggregation : bool

/// A visual representation of a data tree, where each node can have zero or more children, and one parent (except for the root, which has no parents). Each node is displayed as a rectangle, sized and colored according to values that you assign. Sizes and colors are valued relative to all other nodes in the graph. You can specify how many levels to display simultaneously, and optionally to display deeper levels in a hinted fashion. If a node is a leaf node, you can specify a size and color; if it is not a leaf, it will be displayed as a bounding box for leaf nodes. The default behavior is to move down the tree when a user left-clicks a node, and to move back up the tree when a user right-clicks the graph.
/// The total size of the graph is determined by the size of the containing element that you insert in your page. If you have leaf nodes with names too long to show, the name will be truncated with an ellipsis (...).
[<Name "google.visualization.TreeMap">]
[<Require(typeof<Dependencies.JsApi>)>]
[<Require(typeof<Dependencies.TreeMap>)>]
type TreeMap =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: TreeMapOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    [<Stub>]
    member this.getSelection() : obj = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    [<Stub>]
    member this.setSelection(selection: obj) : unit = X

    /// Move up the tree by one level and redraw it. Does not throw an 
    /// error if the node is the root node. This is fired automatically 
    /// when the user right-clicks a node.
    [<Stub>]
    member this.goUpAndDraw() : unit = X

    /// Returns the maximum possible depth for the current view.
    [<Stub>]
    member this.getMaxPossibleDepth() : unit = X

    [<Stub>]
    member this.clearChart() = X<unit>

