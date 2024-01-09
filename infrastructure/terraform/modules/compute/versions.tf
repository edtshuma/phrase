# Terraform settings
terraform {
  required_providers {
    digitalocean = {
      source  = "digitalocean/digitalocean"
      version = ">=2.15.0"
    }
  }
}