pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git url:'https://github.com/brthomasusa/AdventureWorksCycles.git', branch: 'development', credentialsId: '1'
            }
        }
        stage('Clean') {
            steps {
                sh "dotnet clean ${workspace}/AdventureWorksCycles.sln"    
            }
        }
        stage('Build') {
            steps {
                sh "dotnet build -m ${workspace}/AdventureWorksCycles.sln"    
            }
        }
        stage('Unit Test') {
            steps {
                sh "dotnet test --no-restore --nologo -v q --filter AWC.UnitTest"
            }
        }
        stage('Integration Test') {
            steps {
                sh "dotnet test --no-restore --nologo -v q --filter AWC.IntegrationTest"
            } 
        }
    }
}