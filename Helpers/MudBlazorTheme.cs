using MudBlazor;
using System;
using System.Globalization;

namespace MudBlazorServerId.Helpers
{
    public class MudBlazorTheme
    {
        public event Action? OnChange;

        // ** this is the start of the main theme objects

        private String _companyName = "";
        public String CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private String _dialogTitle = "";
        public String DialogTitle
        {
            get { return _dialogTitle; }
            set { _dialogTitle = value; }
        }

        private String _deleteDialogTitle = "";
        public String DeleteDialogTitle
        {
            get { return _deleteDialogTitle; }
            set { _deleteDialogTitle = value; }
        }

        private String _ipAddress = "";
        public String IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        private String _userAgent = "";
        public String UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        private String _userName = "";
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private bool _loggingEnabled = true;

        public Boolean LoggingEnabled
        {
            get { return _loggingEnabled; }
            set { _loggingEnabled = value; }
        }

        private bool _loggingPageEnabled = true;

        public Boolean LoggingPageEnabled
        {
            get { return _loggingPageEnabled; }
            set { _loggingPageEnabled = value; }
        }

        private Boolean _darkTheme = false;
        public Boolean DarkTheme
        {
            get { return _darkTheme; }
            set { _darkTheme = value; }
        }

        private Breakpoint _pageBreakpoint = Breakpoint.Lg;
        public Breakpoint PageBreakpoint
        {
            get { return _pageBreakpoint; }
            set { _pageBreakpoint = value; }
        }

        private Breakpoint _listBreakpoint = Breakpoint.Sm;
        public Breakpoint ListBreakpoint
        {
            get { return _listBreakpoint; }
            set { _listBreakpoint = value; }
        }

        private Typo _pageHeader = Typo.h4;
        public Typo PageHeader
        {
            get { return _pageHeader; }
            set { _pageHeader = value; }
        }

        private Typo _subHeader = Typo.h5;
        public Typo SubHeader
        {
            get { return _subHeader; }
            set { _subHeader = value; }
        }

        private Typo _normalText = Typo.h6;
        public Typo NormalText
        {
            get { return _normalText; }
            set { _normalText = value; }
        }

        private CultureInfo _mudCultureInfo = CultureInfo.CurrentCulture;
        public CultureInfo MudCultureInfo
        {
            get { return _mudCultureInfo; }
            set { _mudCultureInfo = value; }
        }

        private Margin _mudMenuMargin = Margin.Dense;
        public Margin MudMenuMargin
        {
            get { return _mudMenuMargin; }
            set { _mudMenuMargin = value; }
        }

        private MudBlazor.Color _mudMenuColour = MudBlazor.Color.Primary;
        public MudBlazor.Color MudMenuColour
        {
            get { return _mudMenuColour; }
            set { _mudMenuColour = value; }
        }

        private Variant _mudVariant = Variant.Outlined;
        public Variant MudVariant
        {
            get { return _mudVariant; }
            set { _mudVariant = value; }
        }

        private Variant _mudButtonVariant = Variant.Filled;
        public Variant MudButtonVariant
        {
            get { return _mudButtonVariant; }
            set { _mudButtonVariant = value; }
        }

        private Variant _mudCancelButtonVariant = Variant.Text;
        public Variant MudCancelButtonVariant
        {
            get { return _mudCancelButtonVariant; }
            set { _mudCancelButtonVariant = value; }
        }

        private Variant _mudFieldVariant = Variant.Filled;
        public Variant MudFieldVariant
        {
            get { return _mudFieldVariant; }
            set { _mudFieldVariant = value; }
        }

        private Variant _mudDarkSearchVariant = Variant.Filled;
        public Variant MudDarkSearchVariant
        {
            get { return _mudDarkSearchVariant; }
            set { _mudDarkSearchVariant = value; }
        }

        private int _mudNoteLines = 3;
        public int MudNoteLines
        {
            get { return _mudNoteLines; }
            set { _mudNoteLines = value; }
        }

        private int _mudBigNoteLines = 6;
        public int MudBigNoteLines
        {
            get { return _mudBigNoteLines; }
            set { _mudBigNoteLines = value; }
        }

        private Adornment _mudAdornment = Adornment.End;
        public Adornment MudAdornment
        {
            get { return _mudAdornment; }
            set { _mudAdornment = value; }
        }

        private bool _mudDense = true;
        public bool MudDense
        {
            get { return _mudDense; }
            set { _mudDense = value; }
        }

        private Size _mudSize = Size.Small;
        public Size MudSize
        {
            get { return _mudSize; }
            set { _mudSize = value; }
        }

        private Size _mudIconSize = Size.Medium;
        public Size MudIconSize
        {
            get { return _mudIconSize; }
            set { _mudIconSize = value; }
        }

        private Size _mudAddIconSize = Size.Large;
        public Size MudAddIconSize
        {
            get { return _mudAddIconSize; }
            set { _mudAddIconSize = value; }
        }

        private bool _mudImmediate = true;
        public bool MudImmediate
        {
            get { return _mudImmediate; }
            set { _mudImmediate = value; }
        }

        private int _mudCardElevation = 25;
        public int MudCardElevation
        {
            get { return _mudCardElevation; }
            set { _mudCardElevation = value; }
        }

        private bool _mudCardSquare = true;
        public bool MudCardSquare
        {
            get { return _mudCardSquare; }
            set { _mudCardSquare = value; }
        }

        private bool _mudNoteExpanded = true;
        public bool MudNoteExpanded
        {
            get { return _mudNoteExpanded; }
            set { _mudNoteExpanded = value; }
        }

        private int _mudNoteMaxHeight = 150;
        public int MudNoteMaxHeight
        {
            get { return _mudNoteMaxHeight; }
            set { _mudNoteMaxHeight = value; }
        }

        private bool _mudDisableUnderline = false;
        public bool MudDisableUnderline
        {
            get { return _mudDisableUnderline; }
            set { _mudDisableUnderline = value; }
        }

        private string _dateFormat = "";
        public string DateFormat
        {
            get { return _dateFormat; }
            set { _dateFormat = value; }
        }

        private string _timeFormat = "";
        public string TimeFormat
        {
            get { return _timeFormat; }
            set { _timeFormat = value; }
        }

        private string _dateTimeFormat = "";
        public string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set { _dateTimeFormat = value; }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}