#!/bin/bash

oc process -f openshift/sonarcube.bc.json --param-file=process.env