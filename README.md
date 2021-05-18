# How to K8s CronJob
This repository goes through how to create a Kubernetes CronJob

## Resources
* [Cron jobs](https://kubernetes.io/docs/concepts/workloads/controllers/cron-jobs/)
* [Kubernetes local](https://kubernetes.io/blog/2020/05/21/wsl-docker-kubernetes-on-the-windows-desktop/)

## Repository structure

```
├── README.md
├── deploy <-- Generated k8s deployment files produced by ./script/build
│   ├── deployment.development.yaml
│   └── deployment.production.yaml
├── kube <-- K8s deployment template
│   └── deployment.yaml
├── scripts
│   └── build <-- Build script
└── src
    └── HelloWorldJob <-- hello-world-job
        └── Dockerfile
```

## Local Setup
To try things out on your own machine you will need to have your won k8s cluser.
This can be achived using Docker Desktop or Minikube.
* [Kubernetes](https://kubernetes.io/blog/2020/05/21/wsl-docker-kubernetes-on-the-windows-desktop/)


## Step by Step

1. Create Console app
1. Dockerfile
1. Build Docker file
```
docker build -t "hello-world-job" -f src/HelloWorldJob/Dockerfile .
```
1. Build deployment
```
./script/build
```
1. Deployment to local cluster
```sh
# Create CronJob from deployment file

kubectl create -f deploy/deployment.development.yaml

# Get CronJob
kubectl get cronjobs

# Get jobs
kubectl get jobs

# Get pods
kubectl get pods

# Get logs
kubectl logs <pod-name>

# Delete CronJob
kubectl delete -f deploy/deployment.development.yaml
```
