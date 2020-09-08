

if [ -z "$API_URL" ]
then
    echo "You need define the API_URL variable in App Center"
    exit
fi

if [ -z "$APP_SECRETS" ]
then
    echo "You need define the APP_SECRETS variable in App Center"
    exit
fi

if [ -z "$APP_CENTERIOS" ]
then
    echo "You need define the APP_CENTERIOS variable in App Center"
    exit
fi

if [ -z "$APP_CENTERANDROID" ]
then
    echo "You need define the APP_CENTERANDROID variable in App Center"
    exit
fi

APP_CONSTANT_FILE=$APPCENTER_SOURCE_DIRECTORY/src/SolidarityDollar/SolidarityDollar/AppConstant.cs

if [ -e "$APP_CONSTANT_FILE" ]
then
    echo "Updating ApiUrl to $API_URL in AppConstant.cs"
    sed -i '' 's#ApiUrl = "[-A-Za-z0-9:_./]*"#ApiUrl = "'$API_URL'"#' $APP_CONSTANT_FILE

    echo "Updating ApiKeyDolarSolidario to $APP_SECRETS in AppConstant.cs"
    sed -i '' 's#ApiKeyDolarSolidario = "[-A-Za-z0-9:_./]*"#ApiKeyDolarSolidario = "'$APP_SECRETS'"#' $APP_CONSTANT_FILE
    
    echo "Updating AppCenterKeyiOS to $APP_CENTERIOS in AppConstant.cs"
    sed -i '' 's#AppCenterKeyiOS = "[-A-Za-z0-9:_./]*"#AppCenterKeyiOS = "'$APP_CENTERIOS'"#' $APP_CONSTANT_FILE

     echo "Updating AppCenterKeyAndroid to $APP_CENTERANDROID in AppConstant.cs"
    sed -i '' 's#AppCenterKeyAndroid = "[-A-Za-z0-9:_./]*"#AppCenterKeyAndroid = "'$APP_CENTERANDROID'"#' $APP_CONSTANT_FILE
  
     echo "File content:"
    cat $APP_CONSTANT_FILE
    
fi