# Linux Calculator - Deployment Guide

## Project Overview

This is a cross-platform .NET calculator ported from the Windows Calculator UWP app to run on Linux. The calculator has been completely rewritten to use:
- **.NET 9.0** (cross-platform)
- **Console-based UI** (works on any terminal)
- **Pure C#** (no C++ dependencies)

## Files Generated

### Source Files
- `Calculator.cs` - Core calculation engine with all math operations
- `Program.cs` - Interactive console UI
- `LinuxCalculator.csproj` - .NET project file configured for Linux

### Build Output
- `publish/linux/LinuxCalculator` - Self-contained Linux executable (~71 MB)
- Includes .NET runtime - no dependencies needed on target system

## Deployment Steps

### Current Location
The project is located at: `C:\Users\danie\calc_linux`

### Target Location (Linux)
Deploy to: `danie@AI-logic-lab:/mnt/c/Users/danie/calc_linux`

### Method 1: Direct Copy (if using WSL)
```bash
# The executable is already accessible from WSL at:
cd /mnt/c/Users/danie/calc_linux
chmod +x publish/linux/LinuxCalculator
./publish/linux/LinuxCalculator
```

### Method 2: Copy to Linux System
```bash
# From Windows PowerShell or CMD:
scp C:\Users\danie\calc_linux\publish\linux\LinuxCalculator danie@AI-logic-lab:/mnt/c/Users/danie/calc_linux/

# Then on Linux:
ssh danie@AI-logic-lab
cd /mnt/c/Users/danie/calc_linux
chmod +x LinuxCalculator
./LinuxCalculator
```

### Method 3: Using the Deploy Script
```bash
# Make the script executable
chmod +x /mnt/c/Users/danie/calc_linux/deploy.sh

# Run deployment
/mnt/c/Users/danie/calc_linux/deploy.sh
```

## Running the Calculator

Once deployed:
```bash
cd /mnt/c/Users/danie/calc_linux
./LinuxCalculator
```

## Features

### 1. Basic Operations
- Addition (+)
- Subtraction (-)
- Multiplication (*)
- Division (/)

### 2. Scientific Functions
- Square Root (√)
- Power (x^y)
- Trigonometric functions:
  - Sine (sin)
  - Cosine (cos)
  - Tangent (tan)
- Logarithms:
  - Base 10 (log10)
  - Natural (ln)
- Factorial (n!)

### 3. Memory Operations
- MS (Memory Store)
- MR (Memory Recall)
- M+ (Memory Add)
- M- (Memory Subtract)
- MC (Memory Clear)

### 4. Expression Evaluator
- Evaluate complex mathematical expressions
- Example: `5 + 3 * 2`

## Technical Details

### Original Windows Calculator Components
The Windows Calculator uses:
- **UWP (Universal Windows Platform)** - Windows-only
- **C++ calculation engine** (CalcManager)
- **XAML UI** - Windows-specific
- **Platform-specific dependencies**

### Our Linux Port
This version:
- **Cross-platform .NET 9.0**
- **Pure C# calculation engine**
- **Console UI** - works on any terminal
- **No platform dependencies**
- **Self-contained** - includes .NET runtime

### Build Configuration
```xml
<PropertyGroup>
  <TargetFramework>net9.0</TargetFramework>
  <RuntimeIdentifiers>linux-x64;win-x64;osx-x64</RuntimeIdentifiers>
  <PublishSingleFile>true</PublishSingleFile>
  <SelfContained>true</SelfContained>
</PropertyGroup>
```

## Rebuilding from Source

### Prerequisites
- .NET 9.0 SDK installed

### Build for Linux
```bash
cd C:\Users\danie\calc_linux
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

## Testing

### Test on Windows (via WSL)
```bash
wsl
cd /mnt/c/Users/danie/calc_linux/publish/linux
chmod +x LinuxCalculator
./LinuxCalculator
```

### Test Basic Operations
1. Select option 1 (Basic Operations)
2. Enter: 5
3. Enter: +
4. Enter: 3
5. Expected result: 8

### Test Scientific Functions
1. Select option 2 (Scientific Functions)
2. Select 1 (Square Root)
3. Enter: 16
4. Expected result: 4

## Troubleshooting

### Permission Denied
```bash
chmod +x LinuxCalculator
```

### File Not Found
Check the executable is in the current directory:
```bash
ls -la LinuxCalculator
```

### .NET Runtime Issues
This is a self-contained build, so it includes the runtime. If you still have issues:
```bash
# Check file type
file LinuxCalculator

# Expected output: ELF 64-bit LSB executable
```

## Comparison: Original vs Linux Port

| Feature | Windows Calculator | Linux Port |
|---------|-------------------|------------|
| Platform | Windows 10+ only | Linux, Windows, macOS |
| UI | UWP/XAML GUI | Console/Terminal |
| Language | C++ & C# | Pure C# |
| Dependencies | Windows SDK, UWP | None (self-contained) |
| Size | ~50 MB installed | 71 MB single file |
| Basic Math | ✓ | ✓ |
| Scientific | ✓ | ✓ |
| Programmer Mode | ✓ | ✗ |
| Graphing | ✓ | ✗ |
| Unit Converter | ✓ | ✗ |
| Date Calculator | ✓ | ✗ |

## Future Enhancements

Potential additions:
1. **GUI Version** using Avalonia UI or GTK#
2. **Programmer Mode** (binary, hex, octal)
3. **History Viewer**
4. **Configuration File** for settings
5. **Unit Converter**
6. **Date Calculator**

## Support

For issues or questions, refer to:
- Original Windows Calculator: https://github.com/microsoft/calculator
- .NET Documentation: https://docs.microsoft.com/dotnet

## License

This port maintains compatibility with the original Windows Calculator's MIT License.
