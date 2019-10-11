#!/bin/bash



oc process -f openshift/sonarqube.bc.yaml \
    -p NAME=sonarqube \
    -p VERSION=v1 \
    -p SOURCE_REPOSITORY_URL=https://github.com/SierraSystems/FAMS3-POC.git \
    -p SOURCE_REPOSITORY_REF=feature/add-cicd | oc create -f -


oc process -f openshift/sonar-postgresql.bc.yaml \
    -p NAME=sonarqube-postgresql \
    -p VERSION=v1 | oc create -f -


oc process -f openshift/sonar-postgresql.dc.yaml \
    -p NAME=sonarqube-postgresql \
    -p DATABASE_SERVICE_NAME=sonarqube-postgresql \
    -p IMAGE_STREAM_NAME=sonarqube-postgresql \
    -p IMAGE_STREAM_VERSION=v1 \
    -p POSTGRESQL_DATABASE=sonarqube \
    -p VOLUME_CAPACITY=5Gi | oc create -f -

oc process -f openshift/sonarqube.dc.yaml \
    -p NAME=sonarqube \
    -p DATABASE_SERVICE_NAME=sonarqube-postgresql \
    -p DATABASE_NAME=sonarqube \
    -p VERSION=v1 | oc create -f -


