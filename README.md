# Visualise 3D

A generic tool for displaying data points in space!

This can be used for representing entities on a 3 dimensional ranking from 0 to 10.

Data points are mapped to RBG color based on coordinate.

Coordinate system axes are translated to (5,5,5) because it looks kewl.

## Instructions

### Preparation

Create a json configuration according to the structure shown below.

Rules of configuration:

- Coordinates must be within a 10x10x10 cube, coordinates range: ([0-10],[0-10],[0-10])
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
    "ZDescription": "Valg ue of Z"
  }
}
```
Please see `example-full.json` for an example with more data points.

### Start Program

- Download latest release package for your platform.
- Unpack into desired directory
- Run `visualise-3d` binary

### Intro scene

- Load your configuration using the `Load File` button.
- Program will validate configuration before starting visualisation.
- Quit program using the `Quit` button.

### In-Game

- Rotate camera using arrow keys
- Click text of datapoint to zoom in.
- User is presented with a panel with additional information.
- Close panel to zoom out.
- Return to intro scene by pressing `Esc`.

## Known issues

1. Data points with same coordinate will block each other (Grouping needed)

## Developers

### Prerequisites

- Ubuntu 20.04 (only developed here)
- sudo apt install libtinfo5
- Unity 2020.3.33f1

### Versioning

Version is autogenerated from latest base tag of the form `v[major].[minor]` that are pushed manually.

Release versions are of the form `[major].[minor].[patch]`, where patch are the number of commits since base tag.
Unity's own versioning system did not work and this is a not-so-robust work around.

See `./Utils/version.sh` how release versions are set.