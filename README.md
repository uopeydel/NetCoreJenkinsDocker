# NetCoreJenkinsDocker
Just For Test 
NetCore 5.0 With Jenkins With Docker

http://localhost:7010/weatherforecast
 
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
$env:DOCKER_HOST="tcp://0.0.0.0:2375" 
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 
docker rmi $(docker images --filter "dangling=true" -q --no-trunc) 
docker rm $(docker stop $(docker ps -q -f "name=netcorejenkinsdocker") )
docker rmi $(docker images 'netcorejenkinsdocker' -a -q)

cd
rm -rf app
mkdir app
cd app
 
git init
git pull https://username:password@github.com/uopeydel/NetCoreJenkinsDocker.git Dev
   
docker build --progress=plain --pull --rm -f "Dockerfile" -t netcorejenkinsdocker:v1 "."
docker run -it -d -p 7010:80 --name netcorejenkinsdockertest netcorejenkinsdocker:v1 
  
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


# ----kubernate


docker tag {image-id} lapadol/<imagename>:<tag>
docker push lapadol/<imagename>:<tag>

 
# create namespace
kubectl create namespace ncnamespace

# apply config
 
kubectl apply -f nc-deploy.yaml
kubectl apply -f nc-service.yaml

# see all detail
kubectl get pod -A   
kubectl get services -A
kubectl get deployment -A 

kubectl describe pod -n ncnamespace

kubectl config view  
kubectl get svc -w
kubectl get pods -o wide
kubectl get endpoints 
kubectl proxy
 
# ----------------------- delete
kubectl delete --all services
kubectl delete --all deployments
kubectl delete --all pods 
kubectl delete --all namespace
