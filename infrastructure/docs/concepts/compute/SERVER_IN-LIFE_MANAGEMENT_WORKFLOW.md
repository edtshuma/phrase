
<!-- ABOUT -->
## About 
owner: "edtshuma"

title: Server In-Life Management Workflow 

last_reviewed_on: last_reviewed_on: 2024-01-09

review_in: 6 months


<p align="right"></p>


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

In most cases it is not necessary to install ansible on a machine after provisioning it since there is no daemon  required to be able to execute ansible tasks on a remote machine. With this in mind we will NOT install ansible on the server. We will instead configure the server via the ansible agent installed on our local workstation (the remote machine in this instance).




### Provisioning

_Below is a set of steps for installing Ansible on a Windows based workstation._

1. Install Ansible at [TutorialsPoint](https://www.tutorialspoint.com/how-to-install-and-configure-ansible-on-windows)

## TODO

| Feature                  | Description | Screenshot |
|:---------------------------|:------------|:----------:|
| Ansible Provisioner|Cloud Firewall resource for the droplet should be configured in the console and also imported into Terraform configuration. | [LINK](https://about.gitlab.com/topics/gitops/) |
| Packer | The server should be provisioned with  a customised AMI to ensure standardisation and maximisation of reuse. | [LINK](https://www.packer.io/) |
| IP Addressing   | There should be a lookup repository for IP range allocation to ensure that the address alooacted is unique and does not overlaps with other subnets. | [LINK](https://raw.githubusercontent.com/dotdc/media/main/grafana-dashboards-kubernetes/k8s-system-coredns.png) |
| Network Segmentation     | The server should be provisioned in a software defined network(VPC) to segregate it from other types of workloads e.g database and increase security/granulity. | [LINK](https://docs.digitalocean.com/products/networking/vpc/) |
| Network Monitoring  | There should be utility to provide logs of data coming into and out of attached network interfaces. | [LINK](https://docs.digitalocean.com/products/monitoring/how-to/install-agent/) |
| Automated Tests  | There should be integration and unit tests on Terraform code (via CI/CD pipelines) where possible. Tools like tfsec, Checkov and OPA should be used. Only PRs that pass defined tests should deploy to production. | [LINK](https://spacelift.io/blog/what-is-tfsec) |
|   |


<p align="right">(<a href="#readme-top">back to top</a>)</p>
