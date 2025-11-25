#!/bin/bash

# Install required libraries for Avalonia GUI on Linux
echo "Installing GUI dependencies for Calculator..."

sudo apt-get update
sudo apt-get install -y \
    libice6 \
    libsm6 \
    libx11-6 \
    libxext6 \
    libxrender1 \
    libxrandr2 \
    libfontconfig1 \
    libxi6 \
    libxcursor1

echo "Dependencies installed successfully!"
echo "Now you can run: ./CalculatorGUI"
