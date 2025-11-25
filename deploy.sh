#!/bin/bash

# Deploy Linux Calculator
# This script deploys the calculator to the Linux deployment directory

echo "╔══════════════════════════════════════════╗"
echo "║   Linux Calculator Deployment Script    ║"
echo "╚══════════════════════════════════════════╝"
echo ""

# Set deployment directory
DEPLOY_DIR="/mnt/c/Users/danie/calc_linux"

# Check if we're running on WSL or Linux
if [ -d "/mnt/c" ]; then
    echo "Running on WSL - using Windows path..."
    DEPLOY_DIR="/mnt/c/Users/danie/calc_linux"
else
    echo "Running on Linux - using Linux path..."
    DEPLOY_DIR="/home/danie/calc_linux"
fi

echo "Deployment directory: $DEPLOY_DIR"

# Create deployment directory if it doesn't exist
mkdir -p "$DEPLOY_DIR"

# Copy the published binary
if [ -f "$DEPLOY_DIR/publish/linux/LinuxCalculator" ]; then
    echo "Copying Linux executable..."
    cp "$DEPLOY_DIR/publish/linux/LinuxCalculator" "$DEPLOY_DIR/"
    chmod +x "$DEPLOY_DIR/LinuxCalculator"
    echo "✓ Executable copied and made executable"
else
    echo "✗ Error: LinuxCalculator binary not found in publish/linux/"
    echo "  Please run: dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true"
    exit 1
fi

# Copy README
if [ -f "$DEPLOY_DIR/README.md" ]; then
    echo "✓ README.md already in place"
else
    echo "✗ Warning: README.md not found"
fi

echo ""
echo "╔══════════════════════════════════════════╗"
echo "║   Deployment Complete!                   ║"
echo "╚══════════════════════════════════════════╝"
echo ""
echo "To run the calculator:"
echo "  cd $DEPLOY_DIR"
echo "  ./LinuxCalculator"
echo ""
