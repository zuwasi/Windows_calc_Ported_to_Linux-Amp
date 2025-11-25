# Linux Cross-Platform Calculator

A .NET-based calculator ported from the Windows Calculator project to run on Linux.

## Features

- **Basic Operations**: Addition, Subtraction, Multiplication, Division
- **Scientific Functions**: 
  - Square Root
  - Power (x^y)
  - Trigonometric functions (Sin, Cos, Tan)
  - Logarithms (log10, ln)
  - Factorial
- **Memory Operations**: Store, Recall, Add, Subtract, Clear
- **Expression Evaluator**: Evaluate complex mathematical expressions

## Requirements

- .NET 9.0 Runtime (or self-contained build)

## Building

### For Linux (from Windows):
```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

### For Windows:
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### For macOS:
```bash
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```

## Running on Linux

1. Copy the published executable to your Linux machine at `/mnt/c/Users/danie/calc_linux/`
2. Make it executable:
   ```bash
   chmod +x LinuxCalculator
   ```
3. Run it:
   ```bash
   ./LinuxCalculator
   ```

## Usage

The calculator provides an interactive menu with the following options:

1. **Basic Operations**: Perform arithmetic operations
2. **Scientific Functions**: Access advanced mathematical functions
3. **Memory Operations**: Store and recall values
4. **Expression Evaluator**: Evaluate complex expressions
5. **Exit**: Close the calculator

## Project Structure

- `Program.cs` - Main application and UI logic
- `Calculator.cs` - Core calculation engine
- `LinuxCalculator.csproj` - Project configuration

## Original Source

Ported from Microsoft's Windows Calculator:
https://github.com/microsoft/calculator

## License

This project follows the same license as the original Windows Calculator (MIT License).
