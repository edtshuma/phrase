#--compute/main.tf---

resource "digitalocean_droplet" "do_droplet" {
    image   = var.image
    name    = var.name
    region  = var.region
    size    = var.size
    tags    = var.tags
}

