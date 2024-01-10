#--compute/main.tf---

resource "digitalocean_droplet" "do_droplet" {
    image   = var.image
    name    = var.name
    region  = var.region
    size    = var.size
    tags    = var.tags
}

resource "null_resource" "ansible_install" {
depends_on = [digitalocean_droplet.do_droplet] 
 connection {
    type        = "ssh"
    user        = var.ssh_user
    password    = var.ssh_user
    private_key = file("~/.ssh/goldkey")
    host        = var.host
  }
   
   provisioner "file" {
    source      = "install.sh"
    destination = "/tmp/install.sh"
  }
   provisioner "remote-exec" {
    inline = [
      "chmod +x /tmp/install.sh",
      "sudo /tmp/install.sh args",
    ]
  }
}