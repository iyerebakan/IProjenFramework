pipeline {
    agent any 
    stages {
        stage('Build') {
            steps {
                echo 'Build Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/IProjenFramework.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/IProjenFramework.sln\""
                echo 'Build Ends'
            }
        }
		
		stage('Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"${workspace}/IdentityServer\" --output \"C:/WebApis/IdentityServer\""
                echo 'Deploy Ends'
            }
        }		
        
        stage('Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"${workspace}/ApiGateway\" --output \"C:/WebApis/ApiGateway\""
                echo 'Deploy Ends'
            }
        }	
        
        stage('Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"${workspace}/WebAPI\" --output \"C:/WebApis/WebAPI\""
                echo 'Deploy Ends'
            }
        }	
    }
}
