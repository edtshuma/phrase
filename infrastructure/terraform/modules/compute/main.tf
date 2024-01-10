#--compute/main.tf---

resource "digitalocean_droplet" "do_droplet" {
    image   = var.image
    name    = var.name
    region  = var.region
    size    = var.size
    tags    = var.tags
}

resource "local_file" "ip" {
    content  = digitalocean_droplet.do_droplet.ipv4_address
    filename = "ip.txt"
}

resource "null_resource" "ansible_install" {
depends_on = [digitalocean_droplet.do_droplet] 
 connection {
    type        = var.connection_type
    user        = var.ssh_user
    private_key = file("~/.ssh/goldkey")
    host        = var.host
  }
 
 provisioner "file" {
    source      = "ip.txt"
    destination = "/home/gold/phrase/ip.txt"
    }
  
}