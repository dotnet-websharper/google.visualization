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

namespace IntelliFactory.WebSharper.Google.Visualization.Formatters

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.Google.Visualization.Base.Helpers

[<AbstractClass>]
type Formatter() =
    [<Stub>]
    member this.format(data: DataTable, index: int) = ()

type ArrowFormatOptions = 
    [<Inline "{base : $f}">]
    static member Base (f: float) : ArrowFormatOptions = X

[<Name "google.visualization.ArrowFormat">]
type ArrowFormat =
    inherit Formatter
    [<Stub>]
    new () = {}
    [<Stub>]
    new (options: ArrowFormatOptions) = {}

type BarFormatOptions = {

    /// A number that is the base value to compare the cell value against. If the cell value
    /// is higher, it will be drawn to the right of the base; if lower, it will be drawn to
    /// the left. Default value is 0.
    [<Name "base">]
    base' : float

    /// A string indicating the negative value section of bars. Possible values are 'red',
    /// 'green' and 'blue'; default value is 'red'.
    colorNegative : string

    /// A string indicating the color of the positive value section of bars. Possible values
    /// are 'red', 'green' and 'blue'. Default is 'blue'.
    colorPositive : string

    /// A boolean indicating if to draw a 1 pixel dark base line when negative values are
    /// present. The dark line is there to enhance visual scanning of the bars. Default value
    /// is 'false'.
    drawZeroLine : bool

    /// The maximum number value for the bar range. Default value is the highest value in the
    /// table.
    max : float

    /// The minimum number value for the bar range. Default value is the lowest value in the
    /// table.
    min : float

    /// If true, shows values and bars; if false, shows only bars. Default value is true.
    showValue : bool

    /// Thickness of each bar, in pixels. Default value is 100.
    width : int
} with
    [<JavaScript>]
    static member Default : BarFormatOptions = Empty<BarFormatOptions>

/// Adds a colored bar to a numeric cell indicating whether the cell value
/// is above or below a specified base value.
[<Name "google.visualization.BarFormat">]
type BarFormat =
    inherit Formatter
    [<Stub>]
    new () = {}
    [<Stub>]
    new (options: BarFormatOptions) = {}

/// Assigns colors to the foreground or background of a numeric cell, depending
/// on the cell value. This formatter is an unusual, in that it doesn't take
/// its options in the constructor. Instead, you should call addRange() or 
/// addGradientRange() as many times as you want, to add color ranges, before 
/// calling format(). Colors can be specified in any acceptable HTML format, 
/// for example "black", "#000000", or "#000".
[<Name "google.visualization.ColorFormat">]
type ColorFormat = 
    inherit Formatter
    [<Stub>]
    new () = {}

    /// Specifies a foreground color and/or background color to a cell, depending on the cell
    /// value. Any cell with a value in the specified from—to range (non-inclusive) will be
    /// assigned color and bgcolor. It is important to realize that the range is
    /// non-inclusive, because creating a range from 1—1,000 and a second from 1,000—2,000
    /// will not cover the value 1,000!
    /// 
    ///     * from - [String, Number, Date, DateTime, or TimeOfDay] The lower boundary
    ///       (non-inclusive) of the range, or null. If null, it will match -∞. String
    ///       boundaries are compared alphabetically against string values.
    ///     * to - [String, Number, Date, DateTime, or TimeOfDay] The high boundary
    ///       (non-inclusive) of the range, or null. If null, it will match +∞. String
    ///       boundaries are compared alphabetically against string values.
    ///     * color - The color to apply to text in matching cells. Values can be either
    ///       '#RRGGBB' values or defined color constants, (example: '#FF0000' or 'red').
    ///     * bgcolor - The color to apply to the background of matching cells. Values can be
    ///       either '#RRGGBB' values or defined color constants, (example: '#FF0000' or
    ///       'red').
    [<Stub>]
    member this.addRange(from: obj, to': obj, color: string, bgcolor: string) : unit = X

    /// Assigns a background color from a range, according to the cell value. The color is
    /// scaled to match the cell's value within a range from a lower boundary color to an
    /// upper boundary color. Note that this method cannot compare string values, as
    /// addRange() can. Tip: Color ranges are often hard for viewers to gauge accurately; the
    /// simplest and easiest to read range is from a fully saturated color to white (e.g.,
    /// #FF0000—FFFFFF).
    /// 
    ///     * from - [Number, Date, DateTime, or TimeOfDay] The lower boundary
    ///       (non-inclusive) of the range, or null. If null, it will match -∞.
    ///     * to - [Number, Date, DateTime, or TimeOfDay] The higher boundary (non-inclusive)
    ///       of the range, or null. If null, it will match +∞.
    ///     * color - The color to apply to text in matching cells. This color is the same
    ///       for all cells, no matter what their value.
    ///     * fromBgColor - The background color for cells holding values at the low end of
    ///       the gradient. Values can be either '#RRGGBB' values or defined color constants,
    ///       (example: '#FF0000' or 'red').
    ///     * toBgColor - The background color for cells holding values at the high end of
    ///       the gradient. Values can be either '#RRGGBB' values or defined color constants,
    ///       (example: '#FF0000' or 'red').
    [<Stub>]
    member this.addGradientRange(from: obj, to': obj, color: string, fromBgColor: string, toBgColor: string) : unit = X

type DateFormatOptions = {

    /// A quick formatting option for the date. The following string values are supported,
    /// reformatting the date February 28, 2008 as shown:
    /// 
    ///     * 'short' - Short format: e.g., "2/28/08"
    ///     * 'medium' - Medium format: e.g., "Feb 28, 2008"
    ///     * 'long' - Long format: e.g., "February 28, 2008"
    /// You cannot specify both formatType and pattern.
    /// 
    formatType : string

    /// A custom format pattern to apply to the value, similar to the ICU date and time
    /// format. For example: var formatter3 = new google.visualization.DateFormat({pattern:
    /// "EEE, MMM d, ''yy"}); You cannot specify both formatType and pattern. 
    pattern : string

    /// The time zone in which to display the date value. This is a numeric value, indicating
    /// GMT + this number of time zones (can be negative). Date object are created by default
    /// with the assumed time zone of the computer on which they are created; this option is
    /// used to display that value in a different time zone. For example, if you created a
    /// Date object of 5pm noon on a computer located in Greenwich, England, and specified
    /// timeZone to be -5 (options['timeZone'] = -5, or Eastern Pacific Time in the US), the
    /// value displayed would be 12 noon.
    timeZone : float
} with  
    [<JavaScript>]
    static member Default : DateFormatOptions = Empty<DateFormatOptions>

[<Name "google.visualization.DateFormat">]
type DateFormat =
    inherit Formatter
    [<Stub>]
    new () = {}
    [<Stub>]
    new (options: DateFormatOptions) = {}

type NumberFormatOptions [<Inline "{}">] () =

    /// A character to use as the decimal marker. The default is a dot (.).
    [<DefaultValue>]
    val mutable decimalSymbol : string

    /// A number specifying how many digits to display after the decimal. The 
    /// default is 2. If you specify more digits than the number contains, it 
    /// will display zeros for the smaller values. Truncated values will be 
    /// rounded (5 rounded up).
    [<DefaultValue>]
    val mutable fractionDigits : int

    /// A character to be used to group digits to the left of the decimal into 
    /// sets of three. Default is a comma (,).
    [<DefaultValue>]
    val mutable groupingSymbol : string

    /// The text color for negative values. No default value. Values can be any 
    /// acceptable HTML color value, such as "red" or "#FF0000".
    [<DefaultValue>]
    val mutable negativeColor : string

    /// A boolean, where true indicates that negative values should be surrounded
    /// by parentheses. Default is true.
    [<DefaultValue>]
    val mutable negativeParens : bool

    /// A string prefix for the value, for example "$".
    [<DefaultValue>]
    val mutable prefix : string

    /// A string suffix for the value, for example "%".
    [<DefaultValue>]
    val mutable suffix : string


[<Name "google.visualization.NumberFormat">]
type NumberFormat = 
    inherit Formatter
    [<Stub>]
    new () = {}
    [<Stub>]
    new (options: NumberFormatOptions) = {}

[<Name "google.visualization.PatternFormat">]
type PatternFormat [<Stub>] (pattern: string) =

    /// The standard formatting call, with a few additional parameters:
    /// 
    ///     * dataTable - The DataTable on which to operate.
    ///     * srcColumnIndices - An array of one or more (zero-based) column indices to pull
    ///       as the sources from the underlying DataTable. This will be used as a data
    ///       source for the pattern parameter in the constructor. The column numbers do not
    ///       have to be in sorted order.
    /// 
    ///     * opt_dstColumnIndex - [optional] The destination column to place the output of
    ///       the pattern manipulation. If not specified, the first element in
    ///       srcColumIndices will be used as the destination.
    [<Stub>]
    member this.format(dataTable: DataTable, srcColumnIndices: int []) = X

    [<Stub>]
    member this.format(dataTable: DataTable, srcColumnIndices: int [], opt_dstColumnIndex: int) = X

