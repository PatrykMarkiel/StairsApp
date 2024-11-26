# Stairs Program Documentation

### Overview
This program calculates the structure of stairs based on specified dimensions.

## Project Assumptions
1. The program should determine the number of steps and their dimensions (each step of the stairs should be the same).
2. The input data consists of the height (Hk) and length (Lk) where the stairs are to be located.
3. The program should output three values: the number of steps, the height of each step, and the depth of each step.
4. Size limits:
   - Height between 155 mm and 190 mm 
   - Depth between 240 mm and 300 mm 
5. To create comfortable stairs, the equation \( 2h + s \) (where \( h \) is the height of a single step and \( s \) is the depth of a single step) should equal 590 mm to 650 mm (59 cm - 65 cm).

<div align="center">  
  <img src="https://github.com/user-attachments/assets/693871b3-986c-418e-afa3-063645dca6bb" alt="Stairs Diagram" />
</div>

## Detailed Input Parameters
- **Hk (Height)**: The total height where the stairs will be constructed, measured in millimeters (mm). It must be a positive integer.
- **Lk (Length)**: The total horizontal length available for the stairs, measured in millimeters (mm). It must also be a positive integer.
- **Desired Height Range**: The program will consider heights between 160 mm and 180 mm for each step.
- **Desired Depth Range**: The program will consider depths between 250 mm and 290 mm for each step.
- **Comfort Equation**: The program uses the equation \( 2h + s \) to determine whether the stairs meet comfort standards, where \( h \) is the height of each step and \( s \) is the depth of each step.

## Detailed Output Results
The program will output the following results:
- **Number of Steps**: The total number of steps calculated based on the input height and chosen step height.
- **Height of Each Step (mm)**: The calculated height of each step in millimeters, which should fall within the specified height range.
- **Depth of Each Step (mm)**: The calculated depth of each step in millimeters, which should also be within the specified depth range.
- **Remaining Space**: A descriptive message indicating whether all available space was utilized or if the configuration does not meet comfort requirements.

### Example Output
- **Number of Steps**: 17
- **Height of Each Step**: 183 mm
- **Depth of Each Step**: 244.706 mm
- **Remaining Space**: All available space was used.

## Usage Instructions
1. **Input**: The user should provide the total height (Hk) and total length (Lk) in millimeters through the program's input interface.
2. **Run the Program**: Execute the program to calculate the stair dimensions based on the provided inputs.
3. **Review the Results**: The program will display the calculated number of steps, height and depth of each step, and any messages regarding space utilization.
4. **Adjust Inputs**: If the program indicates that comfortable stairs cannot be created, adjust the height or length inputs and rerun the program until satisfactory results are achieved.

<h1>Test Results</h1>

<table>
    <tr>
        <th>Test</th>
        <th>Hk (mm)</th>
        <th>Lk (mm)</th>
        <th>Number of Steps</th>
        <th>Depth of Each Step (mm)</th>
        <th>Height of Each Step (mm)</th>
        <th>Remaining Space</th>
    </tr>
    <tr>
        <td>1</td>
        <td>3200</td>
        <td>4160</td>
        <td>17</td>
        <td>244.706</td>
        <td>188.235</td>
        <td>All available space was used</td>
    </tr>
    <tr>
        <td>2</td>
        <td>2760</td>
        <td>4810</td>
        <td>16</td>
        <td>300.625</td>
        <td>172.5</td>
        <td>All available space was used</td>
    </tr>
    <tr>
        <td>3</td>
        <td>1720</td>
        <td>3120</td>
        <td>10</td>
        <td>310</td>
        <td>172</td>
        <td>Remaining free space in length: 20 mm</td>
    </tr>
    <tr>
        <td>4</td>
        <td>2030</td>
        <td>3210</td>
        <td>11</td>
        <td>291.818</td>
        <td>184.545</td>
        <td>All available space was used</td>
    </tr>
    <tr>
        <td>5</td>
        <td>1730</td>
        <td>3850</td>
        <td>10</td>
        <td>310</td>
        <td>173</td>
        <td>Remaining free space in length: 750 mm</td>
    </tr>
</table>

