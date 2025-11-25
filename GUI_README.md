# Linux Calculator - GUI Version

## ✅ Avalonia GUI Successfully Created!

A modern, cross-platform graphical calculator with Avalonia UI.

## Features

### Display
- Large, easy-to-read display
- Memory indicator (shows "M" when memory has value)
- Real-time calculation history panel

### Calculator Modes

#### Memory Operations (Top Row)
- **MC** - Memory Clear
- **MR** - Memory Recall
- **M+** - Memory Add
- **M-** - Memory Subtract
- **MS** - Memory Store

#### Scientific Functions (Second Row)
- **sin** - Sine (degrees)
- **cos** - Cosine (degrees)
- **tan** - Tangent (degrees)
- **log** - Logarithm base 10
- **ln** - Natural logarithm

#### Advanced Functions
- **%** - Percentage
- **x²** - Square
- **√** - Square Root
- **1/x** - Reciprocal
- **±** - Negate

#### Basic Operations
- Addition (+)
- Subtraction (-)
- Multiplication (×)
- Division (÷)
- Numbers 0-9
- Decimal point (.)
- Equals (=)

### History
- Automatic history tracking
- Shows last calculations
- Clear history button
- Scrollable history panel

## Installation on Linux

### Location
The executable is at: `C:\Users\danie\calc_linux\publish\gui-linux\CalculatorGUI`

### Deploy to Linux

#### Method 1: Using WSL
```bash
# From WSL, the file is accessible at:
cd /mnt/c/Users/danie/calc_linux/publish/gui-linux
chmod +x CalculatorGUI
./CalculatorGUI
```

#### Method 2: Copy to Linux Machine
```bash
# Copy from Windows
scp C:\Users\danie\calc_linux\publish\gui-linux\CalculatorGUI danie@AI-logic-lab:/mnt/c/Users/danie/calc_linux/

# On Linux
ssh danie@AI-logic-lab
cd /mnt/c/Users/danie/calc_linux
chmod +x CalculatorGUI
./CalculatorGUI
```

## File Sizes

- **Console Version**: 71 MB (LinuxCalculator)
- **GUI Version**: ~85 MB (CalculatorGUI)

Both are self-contained and require no dependencies.

## Running the GUI

### Prerequisites
The GUI calculator requires:
- X11 or Wayland display server (standard on most Linux desktops)
- No .NET runtime needed (self-contained)

### Launch
```bash
cd /mnt/c/Users/danie/calc_linux/publish/gui-linux
chmod +x CalculatorGUI
./CalculatorGUI
```

### If Running Headless (No GUI)
If you're on a headless server without X11/Wayland, use the console version instead:
```bash
cd /mnt/c/Users/danie/calc_linux/publish/linux
./LinuxCalculator
```

## UI Layout

```
┌─────────────────────────────────────┐
│ M                            [Memory]│
├─────────────────────────────────────┤
│                              0      │ ← Display
├─────────────────────────────────────┤
│ MC │ MR │ M+ │ M- │ MS │            ← Memory
├─────────────────────────────────────┤
│sin │cos │tan │log │ ln │            ← Scientific
├─────────────────────────────────────┤
│ %  │ CE │ C  │ ⌫  │ ÷  │            ← Functions
├─────────────────────────────────────┤
│ x² │ 7  │ 8  │ 9  │ ×  │
├─────────────────────────────────────┤
│ √  │ 4  │ 5  │ 6  │ -  │
├─────────────────────────────────────┤
│1/x │ 1  │ 2  │ 3  │ +  │
├─────────────────────────────────────┤
│ ±  │ 0  │ .  │    =    │
├─────────────────────────────────────┤
│ History              [Clear]        │
│  5 + 3 = 8                          │
│  √16 = 4                            │
│  ...                                │
└─────────────────────────────────────┘
```

## Technology Stack

- **UI Framework**: Avalonia UI 11.3.9
- **MVVM**: CommunityToolkit.Mvvm 8.2.1
- **Platform**: .NET 9.0
- **Pattern**: MVVM (Model-View-ViewModel)

## Project Structure

```
CalculatorGUI/
├── Views/
│   ├── MainWindow.axaml          - Main window
│   ├── MainWindow.axaml.cs
│   ├── CalculatorView.axaml      - Calculator UI
│   └── CalculatorView.axaml.cs
├── ViewModels/
│   ├── MainWindowViewModel.cs    - Main VM
│   ├── CalculatorViewModel.cs    - Calculator logic
│   └── ViewModelBase.cs
├── Calculator.cs                  - Core engine (shared)
└── CalculatorGUI.csproj
```

## Building from Source

### Build for Linux
```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

### Build for Windows
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### Build for macOS
```bash
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```

## Usage Tips

### Basic Calculations
1. Click numbers to enter
2. Click operation (+, -, ×, ÷)
3. Enter second number
4. Click = to see result

### Memory Functions
1. Calculate a value
2. Click **MS** to store in memory
3. Click **MR** to recall later
4. Click **M+** to add to memory
5. Click **MC** to clear memory

### Scientific Functions
1. Enter a number
2. Click scientific button (sin, cos, √, etc.)
3. Result appears instantly

### History
- Automatically tracks all calculations
- Scroll to see older calculations
- Click "Clear" to reset history

## Comparison: Console vs GUI

| Feature | Console | GUI |
|---------|---------|-----|
| Display | Text-based | Graphical |
| Size | 71 MB | 85 MB |
| Memory Usage | ~30 MB | ~80 MB |
| Input | Keyboard | Mouse/Touch |
| History | Basic | Visual scrollable |
| Platform | All Linux | Needs X11/Wayland |
| Speed | Instant | Instant |
| Look & Feel | Terminal | Modern GUI |

## Troubleshooting

### "Cannot open display"
You're on a headless system. Use the console version instead.

### "Permission denied"
```bash
chmod +x CalculatorGUI
```

### Missing libraries
The app is self-contained, but you might need:
```bash
# Ubuntu/Debian
sudo apt-get install libx11-6 libice6 libsm6

# Fedora/RHEL
sudo dnf install libX11 libICE libSM
```

## Screenshots

The calculator features:
- Clean, modern interface
- Color-coded buttons (numbers, operations, functions)
- Large, readable display
- Real-time history tracking
- Professional layout

## What's Next?

Potential enhancements:
1. Keyboard shortcuts
2. Themes (light/dark mode)
3. Programmer mode (binary, hex)
4. Unit converter
5. Graph plotter
6. Settings panel

## License

Same as the original Windows Calculator (MIT License).
