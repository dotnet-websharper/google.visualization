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
open IntelliFactory.WebSharper.EcmaScript

/// Wrap for selecting the Highlight string.
type HighlightMode = 
    | [<Constant "nearest">] Nearest
    | [<Constant "last">] Last

/// Wrap for selecting the legendPosition string.
type LegendPositioning = 
    | [<Constant "sameRow">] SameRow
    | [<Constant "newRow">] NewRow

/// Wrap for selecting the scaleType string.
type ScaleType = 
    | [<Constant "maximized">] Maximized
    | [<Constant "fixed">] Fixed
    | [<Constant "allmaximized">] AllMaximized
    | [<Constant "allfixed">] AllFixed

/// Wrap for selecting the scaleType string.
type WindowMode = 
    | [<Constant "opaque">] Opaque
    | [<Constant "window">] Window
    | [<Constant "transparent">] Transparent


/// An interactive time series line chart with optional annotations. The chart is
/// rendered within the browser using Flash.
/// 
/// Important: You must specify the height and width of the container element explicitly
/// on your page.
type AnnotatedTimeLineOptions = {
    /// If set to true, formatted values of cells that include HTML tags will be rendered as
    /// HTML. If set to false, most custom formatters will not work properly. Default false
    allowHtml : bool

    /// Enables a more efficient redrawing technique for the second and later calls to draw()
    /// on this visualization. It only redraws the chart area. To use this option, you must
    /// fulfill the following requirements:
    /// 
    ///     * allowRedraw must be true
    ///     * displayAnnotations must be false (that is, you cannot show annotations)
    ///     * you must pass in the same options and values (except for the allowRedraw and
    ///       displayAnnotations) as in your first call to draw().
    allowRedraw : bool

    /// A suffix to be added to all values in the scales and the legend.
    allValuesSuffix : string

    /// The width (in percent) of the annotations area, out of the entire chart area. Must be
    /// a number in the range 5-80.
    annotationsWidth : float

    /// The colors to use for the chart lines and labels. An array of strings. Each element
    /// is a string in a valid HTML color format. For example 'red' or '#00cc00'.
    colors : string []

    /// Either 'MMMM dd, yyyy' or 'HH:mm MMMM dd, yyyy', depending on the type of the first
    /// column (date, or datetime, respectively).  The format used to display the date
    /// information in the top right corner. The format of this field is as specified by the
    /// java SimpleDateFormat class.
    dateFormat : string

    /// If set to true, the chart will show annotations on top of selected values. When
    /// this option is set to true, after every numeric column, two optional annotation
    /// string columns can be added, one for the annotation title and one for the annotation
    /// text.
    displayAnnotations : bool

    /// If set to true, the chart will display a filter contol to filter annotations. Use
    /// this option when there are many annotations.
    displayAnnotationsFilter : bool

    /// Whether to display a small bar separator ( | ) between the series values and the date
    /// in the legend, where true means yes.
    displayDateBarSeparator : bool

    /// Whether to display a shortened, rounded version of the values on the top of the
    /// graph, to save space; false indicates that it may. For example, if set to false,
    /// 56123.45 might be displayed as 56.12k.
    displayExactValues : bool

    /// Whether to display dots next to the values in the legend text, where true means yes.
    displayLegendDots : bool

    /// Whether to display the highlighted values in the legend, where true means yes.
    displayLegendValues : bool

    /// Whether to show the zoom range selection area (the area at the bottom of the chart),
    /// where false means no.
    displayRangeSelector : bool

    /// Whether to show the zoom links ("1d 5d 1m" and so on), where false means no.
    displayZoomButtons : bool

    /// A number from 0—100 (inclusive) specifying the alpha of the fill below each line in
    /// the line graph. 100 means 100% opaque fill, 0 means no fill at all. The fill color is
    /// the same color as the line above it.
    fill : float

    /// Which dot on the series to highlight, and corresponding values to show in the
    /// legend. Select from one of these values:
    /// 
    ///     * 'nearest' - The values closest along the Y axis to the mouse.
    ///     * 'last' - The next set of values to the left of the mouse.
    hightlightDot : HighlightMode

    /// Whether to put the colored legend on the same row with the zoom buttons and the date
    /// ('sameRow'), or on a new row ('newRow').
    legendPosition : LegendPositioning

    /// The maximum value to show on the Y axis. If the maximum data point exceeds this
    /// value, this setting will be ignored, and the chart will be adjusted to show the next
    /// major tick mark above the maximum data point. This will take precedence over the Y
    /// axis maximum determined by scaleType.
    max : float

    /// The minimum value to show on the Y axis. If the minimum data point is less than this
    /// value, this setting will be ignored, and the chart will be adjusted to show the next
    /// major tick mark below the minimum data point. This will take precedence over the Y
    /// axis minimum determined by scaleType.
    min : float

    /// Specifies the number format patterns to be used to format the values at the top of
    /// the graph.
    /// The patterns should be in the format as specified by the java DecimalFormat class.
    /// 
    ///     * If not specified, the default format pattern is used.
    ///     * If a single string pattern is specified, it is used for all of the values.
    ///     * If a map is specified, the keys are (zero-based) indexes of series, and the
    ///       values are the patterns to be used to format the specified series.
    ///       You are not required to include a format for every series on teh chart; any
    ///       unspecified series will use teh default format.
    /// 
    /// If this option is specified, the displayExactValues option is ignored.
    // TODO: Handle the other type
    numberFormats : string

    /// Specifies which values to show on the Y axis tick marks in the graph. The default is
    /// to have a single scale on the right side, which applies to both series; but you can
    /// have different sides of the graph scaled to different series values.
    /// 
    /// This option takes an array of zero to three numbers specifying the (zero-based) index
    /// of the series to use as the scale value. Where these values are shown depends on how
    /// many values you include in your array:
    /// 
    ///     * If you specify an empty array, the chart will not show Y values next to the
    ///       tick marks.
    ///     * If you specify one value, the scale of the indicated series will be displayed
    ///       on the right side of the chart only.
    ///     * If you specify two values, a the scale for the second series will be added to
    ///       the right of the chart.
    ///     * If you specify three values, a scale for the third series will be added to the
    ///       middle of the chart.
    ///     * Any values after the third in the array will be ignored.
    /// 
    /// When displaying more than one scale, it is advisable to set the scaleType option to
    /// either 'allfixed' or 'allmaximized'.
    scaleColumns : float []

    /// Sets the maximum and minimum values shown on the Y axis. The following options are
    /// available:
    /// 
    ///     * 'maximized' - The Y axis will span the minimum to the maximum values of the
    ///       series. If you have more than one series, use allmaximized.
    /// 
    ///     * 'fixed' [default] - The Y axis varies, depending on the data values values:
    /// 
    ///           o If all values are >=0, the Y axis will span from zero to the maximum data
    ///           value.
    /// 
    ///           o If all values are <=0, the Y axis will span from zero to the minimum data
    ///           value.
    /// 
    ///           o If values are both positive and negative, the Y axis will range from the
    ///           series maximum to the series minimum.
    /// 
    ///             For multiple series, use 'allfixed'.
    /// 
    ///     * 'allmaximized' - Same as 'maximized,' but used when multiple scales are
    ///       displayed. Both charts will be maximized within the same scale, which means
    ///       that one will be misrepresented against the Y axis, but hovering over each
    ///       series will display it's true value.
    /// 
    ///     * 'allfixed' - Same as 'fixed,' but used when multiple scales are displayed. This
    ///       setting adjusts each scale to the series to which it applies (use this in
    ///       conjunction with scaleColumns).
    /// 
    /// If you specify the min and/or max options, they will take precedence over the minimum
    /// and maximum values determined by your scale type.
    scaleType : ScaleType

    /// A number from 0—10 (inclusive) specifying the thickness of the lines, where 0 is the
    /// thinnest.
    thickness : float

    /// The Window Mode (wmode) parameter for the Flash chart. Available values are:
    /// 'opaque', 'window' or 'transparent'.
    wmode : WindowMode

    /// Sets the end date/time of the selected zoom range.
    zoomEndTime : Date

    /// Sets the start date/time of the selected zoom range.
    zoomStartTime : Date
} with 
    [<JavaScript>]
    static member Default : AnnotatedTimeLineOptions = Empty<AnnotatedTimeLineOptions>

type VisibleChartRange = {
        [<Name "start">]
        Start : Date
        [<Name "end">]
        End : Date
    }

/// An interactive time series line chart with optional annotations. The chart is
/// rendered within the browser using Flash.
/// 
/// Important: You must specify the height and width of the container element explicitly
/// on your page.
[<Stub>]
[<Name "google.visualization.AnnotatedTimeLine">]
[<Require(typeof<Dependencies.AnnotatedTimeLine>)>]
type AnnotatedTimeLine =
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    member this.draw(data: DataCommon, options: AnnotatedTimeLineOptions) : unit = X

    /// Standard getSelection() implementation. Selected elements are cell elements. Only one
    /// cell can be selected at a time by the user.
    member this.getSelection() : obj = X

    /// Call this method to retrieve information about the current
    /// sort state of a table that has been sorted (typically by the
    /// user, who has clicked on a column heading to sort the rows by a
    /// specific column).
    member this.getSortOrder() : SortOrder = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    member this.setSelection(selection: obj) : unit = X

    /// Returns an object with start and end properties, which each one of them is a Date
    /// object, representing the current time selection.
    member this.getVisibleChartRange() : VisibleChartRange = X

    /// Hides the specified data series from the chart. Accepts one parameter which can be a
    /// number or an array of numbers, in which 0 refers to the first data series, and so on.
    member this.hideDataColumns(columnIndexes: float) : unit = X

    /// Hides the specified data series from the chart. Accepts one parameter which can be a
    /// number or an array of numbers, in which 0 refers to the first data series, and so on.
    member this.hideDataColumns(columnIndexes: float []) : unit = X

    /// Sets the visible range (zoom) to the specified range. Accepts two parameters of type
    /// Date that represent the first and last times of the wanted selected visible
    /// range. Set start to null to include everything from the earliest date to end; set end
    /// to null to include everything from start to the last date.
    member this.setVisibleChartRange(start: Date, end': Date) : unit = X

    /// Shows the specified data series from the chart, after they were hidden using
    /// hideDataColumns method. Accepts one parameter which can be a number or an array of
    /// numbers, in which 0 refers to the first data series, and so on.
    member this.showDataColumns(columnIndexes: float) : unit = X

    /// Shows the specified data series from the chart, after they were hidden using
    /// hideDataColumns method. Accepts one parameter which can be a number or an array of
    /// numbers, in which 0 refers to the first data series, and so on.
    member this.showDataColumns(columnIndexes: float[]) : unit = X