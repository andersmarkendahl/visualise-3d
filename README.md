# Visualise 3D

A generic tool for displaying data points in the space of a cube 10x10x10.

This can be used for representing entities on a 3 dimensional ranking from 0 to 10.

Data points are given a RBG color based on coordinate.

Coordinate system axes are translated to (5,5,5) because it looks kewl.

## Instructions

Load a json configuration according to the structure shown below.

Rules of configuration:

- Coordinates must be within a 10x10x10 cube ([0-10],[0-10],[0-10])
- All fields are mandatory except `Meta.Description`
- Maximum 30 characters for `Meta.Header`
- Maximum 600 characters for `Meta.Description` 
- `DataPoints` is array (arbitrary number of members)

`example-small.json`:
```json
{
  "DataPoints": [
    {
      "Coordinate": {
        "x": 1,
        "y": 2,
        "z": 0
      },
      "Meta": {
        "Header": "Example DataPoint 1",
        "Description": "Example Description"
      }
    },
    {
      "Coordinate": {
        "x": 10,
        "y": 10,
        "z": 6
      },
      "Meta": {
        "Header": "Example DataPoint 2"
      }
    }
  ],
  "Meta": {
    "XLabelStart": "Not Much X",
    "XLabelEnd": "Much X",
    "XDescription": "Value of X",
    "YLabelStart": "Not Much Y",
    "YLabelEnd": "Much Y",
    "YDescription": "Value of Y",
    "ZLabelStart": "Not Much Z",
    "ZLabelEnd": "Much Z",
    "ZDescription": "Value of Z"
  }
}
```
Please see `example-full.json` for an example with more data points.

## Known issues

1. Data points with same coordinate will block each other
2. JSON Validation schema pending 

## Developers

### Prerequisites

- Ubuntu 20.04 (only developed here)
- sudo apt install libtinfo5
- Unity 2020.3.33f1