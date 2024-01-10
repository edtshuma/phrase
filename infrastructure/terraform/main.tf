#--root/main.tf---

module "compute" {
  source = "./modules/compute"
  image  = "ubuntu-20-04-x64"
  name   = "ubuntu-devops"
  region = "sfo3"
  size   = "s-2vcpu-8gb-amd"
  tags   = ["phrase"]
  ssh_user = "gold"
  connection_type = "ssh"
  host = var.host
}
