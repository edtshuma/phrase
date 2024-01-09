
<!-- ABOUT -->
## About 
owner: "edtshuma"

title: Server Provisioning Workflow 

last_reviewed_on: last_reviewed_on: 2024-01-09

review_in: 6 months


<p align="right"></p>


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

Since an existing server was available, the server has been setup using  [Terraform import](https://spacelift.io/blog/importing-exisiting-infrastructure-into-terraform) in the Phrase Platform, with all the code stored in [infrastructure](https://github.com/edtshuma/phrase/tree/main/infrastructure) subdirectory.




### Provisioning

_Below is a set of steps for provisioning the droplet._

1. Create DigitalOcean Account at [DigitalOcean](https://cloud.digitalocean.com/registrations/new)
2. Login to the console and create a DigitalOcean Personal Access Token at [DigitalOcean PAT](https://docs.digitalocean.com/reference/api/create-personal-access-token/)
 
3.  Create a DigitalOcean Linux-based virtual machine (droplet) with a tag at [DigitalOcean Droplets](https://docs.digitalocean.com/products/droplets/how-to/create/)

4. Add a DigitalOcean Cloud Firewall to your Droplet at [DigitalOcean Cloud Firewalls] (https://docs.digitalocean.com/products/networking/firewalls/how-to/create/)

5. Install DigitalOcean Command Line Client on your local machine at [DigitalOcean DOCTL] (https://github.com/digitalocean/doctl/releases)
6. Configure  Access for DigitalOcean Command Line Client(doctl)
   ```sh
   doctl auth init
   ```
7. Verify doctl access: List available Droplets using doctl
  ```sh
  doctl compute droplet list
  ```
8.  Import the droplet into Terraform configuration
   ```sh
   terraform import -var "do_token=${DO_TOKEN}" module.compute.digitalocean_droplet.do_droplet DROPLET-ID 
   ```

## TODO

| Feature                  | Description | Screenshot |
|:---------------------------|:------------|:----------:|
| Cloud Firewall|Cloud Firewall resource for the droplet should be configured in the console and also imported into Terraform configuration. | [LINK](https://about.gitlab.com/topics/gitops/) |
| Packer | The server should be provisioned with  a customised AMI to ensure standardisation and maximisation of reuse. | [LINK](https://www.packer.io/) |
| IP Addressing   | There should be a lookup repository for IP range allocation to ensure that the address alooacted is unique and does not overlaps with other subnets. | [LINK](https://raw.githubusercontent.com/dotdc/media/main/grafana-dashboards-kubernetes/k8s-system-coredns.png) |
| Network Segmentation     | The server should be provisioned in a software defined network(VPC) to segregate it from other types of workloads e.g database and increase security/granulity. | [LINK](https://docs.digitalocean.com/products/networking/vpc/) |
| Network Monitoring  | There should be utility to provide logs of data coming into and out of attached network interfaces. | [LINK](https://docs.digitalocean.com/products/monitoring/how-to/install-agent/) |
| Automated Tests  | There should be integration and unit tests on Terraform code (via CI/CD pipelines) where possible. Tools like tfsec, Checkov and OPA should be used. Only PRs that pass defined tests should deploy to production. | [LINK](https://spacelift.io/blog/what-is-tfsec) |
|   |


<p align="right">(<a href="#readme-top">back to top</a>)</p>
