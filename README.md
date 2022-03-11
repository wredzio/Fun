# 1. Use Assertions in Page Objects

Date: 2022-03-11

## Status 
Proposed

## Context
We are not sure if Page Objects should include assertions.

## Solutions
### Option 1: Page objects include assertions.
This is recomended way for writing Page Objects.

### Option 2: Page objects provides only data and test scripts do the assertions.
With option 2, we would reduce code duplication, and tests would be framework agnostic(all stuff from @testing-library/react would be placed in PageObjects). 

## Decision

## Consecration


