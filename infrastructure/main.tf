#--root/main.tf---

module "compute" {
  source = "./modules/compute"
  image  = "ubuntu-20-04-x64"
  name   = "ubuntu-devops"
  region = "sfo3"
  size   = "s-2vcpu-8gb"
  tags   = ["phrase"]
}
