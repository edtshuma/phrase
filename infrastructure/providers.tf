#--root/providers.tf---
terraform {
  
  required_version = ">= 1.6.6, < 1.7.0"
  required_providers {
    digitalocean = {
      source = "digitalocean/digitalocean"
      version = "~>2.15.0"
    }
  }
}

variable "do_token" {}

provider "digitalocean" {
  token = var.do_token
}