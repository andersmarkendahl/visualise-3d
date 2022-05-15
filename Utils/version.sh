#!/bin/sh
baseTag=$(git tag | grep "v[0-9].[0-9]$" | tail -n 1)
commits=$(git rev-list $baseTag..HEAD --count)
base=$(echo $baseTag | sed 's/v//g')
echo "$base.$commits"