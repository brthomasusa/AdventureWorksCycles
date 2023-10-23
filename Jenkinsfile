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
                script {
                    docker.image('mcr.microsoft.com/mssql/server:2022-latest').withRun(
                        '--volume awc-data:/var/opt/mssql/ ' +
                        '--name awc-db ' +
                        '--publish 1433:1433 ' + 
                        '--env ACCEPT_EULA=Y ' +
                        '--env MSSQL_SA_PASSWORD=Info99Gum ') {

                        sh '''
                            sleep 100
                            dotnet test --no-restore --nologo -v q --filter AWC.IntegrationTest
                        '''
                    }
                }
            } 
        }
    }
}