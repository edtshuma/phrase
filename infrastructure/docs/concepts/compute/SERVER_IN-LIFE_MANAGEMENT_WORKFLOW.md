
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

Terraform will provisioned the server and infrastructure, and Ansible will take care of the in-life management of the server (eg patching).
Ansible daemon will not be installed on developer workstations for such possible use: 

   ```sh
   provisioner "local-exec" {
    command = "ANSIBLE_HOST_KEY_CHECKING=False ansible-playbook -u root -i '${self.ipv4_address},' --private-key ${var.pvt_key} -e 'pub_key=${var.pub_key}' mypackage-install.yml"
  }
   ```
The Ansible controller should be configured at the target remote server end and not developer workstation end.

For now Ansible is installed via "apt" by logging in to the server using the non-root user. However, the recommended way is to use either of the two ways:


1. Installation via Terraform using  ["remote-exec"] (https://github.com/edtshuma/phrase/blob/main/infrastructure/ansible/scripts/install-resource.tf). However, this is not working as the password prompt is still present even when using "/tmp" directory.
 
2. Installation via the Iac "ansible" path -->  An Ansible role will need to be defined at this path - the role will install a script for configuring Ansible on the remote server (one-time).




## TODO

| Feature                  | Description | Screenshot |
|:---------------------------|:------------|:----------:|
| Ansible Agent Installation|Terraform should use SSH through a bastion host(or directly) to the install Ansible on the target server (the Ansible controller).This helps avoid possible conflicts emanating from using of Ansible controller versions installed on engineers's laptops.
. | [LINK](https://github.com/edtshuma/phrase/blob/main/infrastructure/ansible/scripts/install-resource.tf) |
| Ansible Agent Installation     | Ansible Agent Installation|Terraform should use SSH through a bastion host(or directly) to the install Ansible on the target server (the Ansible controller).This helps avoid possible conflicts emanating from using of Ansible controller versions installed on engineers's laptops.. | [LINK](https://github.com/edtshuma/phrase/blob/main/infrastructure/ansible/scripts/install-resource.tf) |
|
|  |
|   |


<p align="right">(<a href="#readme-top">back to top</a>)</p>
