# MtGui Profit Calculator

## Overview
**MtGui Profit Calculator** is a powerful MQL5 script designed to calculate historical profit over a specified period using a user-friendly graphical interface. The interface is provided by the external library **MtGuiController.dll**.

## Features
- **Date Selection**: Choose the date range for profit calculation.
- **Symbol and Magic Filtering**: Filter trades by symbols and magic numbers.
- **Profit Calculation**: Calculate total profit and the number of deals based on selected criteria.
- **User-Friendly Interface**: Easily navigate through options and view results on a graphical panel.

## Installation
1. Clone or download this repository.
   ```bash
   git clone https://github.com/5nail000/MtGui_ProfitCalculator.git
  bash```

2. Copy the contents of the `MQL5` folder into the corresponding folder in your MetaTrader 5 directory:
   - `MQL5\Scripts`
   - `MQL5\Libraries` (Ensure the `MtGuiController.dll` file is placed here)

3. Open MetaEditor and compile the script to ensure there are no errors.

## Usage
1. Start MetaTrader 5.
2. Run the **CalculateHistoryProfit** script from the Navigator panel.
3. Use the graphical panel to select:
   - Start and end dates.
   - Symbols to filter.
   - Magic numbers to filter.
4. Click the **Submit** button to calculate profit.
5. The results, including total profit and number of deals, will be displayed on the panel.

## Requirements
- MetaTrader 5
- **MtGuiController.dll** (included in the repository)

## Contribution
Feel free to contribute to this project by submitting issues or pull requests.

## License
This project is licensed under the MIT License - see the [LICENSE](https://mit-license.org/) file for details.

## Author
Created by Snail000.

## Support
For any questions or issues, please open an issue in the repository.
