#!/bin/bash

helpFunction()
{
   echo ""
   echo "Usage: $0 -d DOTNET_ENV"
   echo -e "\t-d Test result as Dotnet Environment Based"
   exit 1 # Exit script after printing help
}

while getopts "d:" opt
do
   case "$opt" in
      d ) DOTNET_ENV="$OPTARG" ;;
      ? ) helpFunction ;; # Print helpFunction in case parameter is non-existent
   esac
done
wait

rm -rf "./TestResults"
mkdir "TestResults"

echo ""
echo "All test sources will be starts with '$DOTNET_ENV' of environment."
echo "Test logs have been attached to console. Also Code Coverage"
echo "report and test result will be crated after the run process."
echo ""

#Run tests
dotnet test \
        --logger:"junit;LogFilePath=./TestResults/test_result.xml" \
        --logger "console;verbosity=detailed" \
        --collect:"XPlat code coverage" \
        --settings "test.$DOTNET_ENV.runsettings"


echo "-----------------------------"
echo "ALL TESTS HAVE BEEN COMPLETED"
echo "-----------------------------"

#Run Run report output
xunit-viewer  \
        --results=./TestResults/test_result.xml \
        --output=./TestResults/test_results.html \
        --title=" ShopRU CaseStudy" \


cd "./TestResults"        
FILES=(*)
FIRST_DIR="${FILES[0]}"
cd "${FIRST_DIR}"

echo "-----------------------------"
echo "RUN REPORT CREATED"
echo "-----------------------------"

#Run Code Coverage Report output
reportgenerator \
        -reports:coverage.cobertura.xml \
        -targetdir:coveragereport

echo "-----------------------------"
echo "COVERAGE REPORT CREATED"
echo "-----------------------------"
