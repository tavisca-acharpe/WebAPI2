pipeline 
{
    agent any
	parameters 
	{
			string(	name: 'SOLUTION_FILE',
					defaultValue: "WebApplication2.sln", 
					description: 'Project Solution File')

			string(	name: 'TEST_FILE',
					defaultValue: "XUnitTestProject1/WebApiXUnitTest.csproj", 
					description: 'Project Unit Test File')

            string( name: 'DOCKER_USERNAME',
                    defaultValue: "abhishekcharpe", 
                    description: 'Docker Account Username')

            string( name: 'DOCKER_PASSWORD',
                    defaultValue: "abhishek@123", 
                    description: 'Docker Account Password')

            string( name: 'DOCKER_IMAGE',
                    defaultValue: "webapiimage", 
                    description: 'Docker Image Name')

            string( name: 'DOCKER_REPOSITORY',
                    defaultValue: "abhishekcharpe/training_repo", 
                    description: 'Docker Account Repository')

            string( name: 'DOCKER_TAG',
                    defaultValue: "tagname", 
                    description: 'Docker Image Tag')
		
		string( name: 'PORT_NO',
                    defaultValue: "5383", 
                    description: 'Port number')
		
    }
	
    stages 
    {
    	stage('Build') 
        {
            steps 
            {
                echo '_________________________ RESTORE ________________________________'
		bat 'dotnet restore %SOLUTION_FILE% --source https://api.nuget.org/v3/index.json'    

		echo '_________________________ BUILD ________________________________'
                bat 'dotnet build %SOLUTION_FILE% -p:Configuration=release -v:q'
		    
		echo '_________________________ TEST ________________________________'
                bat 'dotnet test %TEST_FILE%'
		    
		echo '_________________________ PUBLISH ________________________________'
                bat 'dotnet publish %SOLUTION_FILE% -c RELEASE -o Publish'    
            }
        }
        stage('Deploy') 
        {
            steps 
            {
                echo '_________________________ BUILD DOCKER IMAGE ________________________________'
                bat 'docker build -t %DOCKER_IMAGE% -f Dockerfile .' 
		
		echo '_________________________ DOCKER USER LOGIN ________________________________'
                bat 'docker login -p %DOCKER_PASSWORD% -u %DOCKER_USERNAME%'
		    
		echo '__________________ DOCKER PUSH IMAGE TO DOCKERHUB ________________________'
                bat 'docker tag %DOCKER_IMAGE% %DOCKER_REPOSITORY%:%DOCKER_TAG%'
                bat 'docker push %DOCKER_REPOSITORY%:%DOCKER_TAG%'
		    
		echo '_________________________ REMOVE OLD IMAGE ________________________________'
                bat 'docker rmi %DOCKER_IMAGE%:latest'
                bat 'docker rmi %DOCKER_REPOSITORY%:%DOCKER_TAG%'
		    
		echo '_________________________ DOCKER IMAGE RUN ________________________________'
                bat 'docker pull %DOCKER_REPOSITORY%:%DOCKER_TAG%'   
		echo "listning on port 5383"
                bat 'docker run --rm -p %PORT_NO%:80 %DOCKER_REPOSITORY%:%DOCKER_TAG% '    
		    
            }
        }
       
    }
}
