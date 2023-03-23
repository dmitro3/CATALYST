const { ethers } = require('hardhat');

// Deploy function
async function deploy() {
   [account] = await ethers.getSigners();
   deployerAddress = account.address;
   console.log(`Deploying contracts using ${deployerAddress}`);

   //Deploy Catalyst
   console.log();
   console.log(":: DEPLOY NINJACATADI");
   const NinjaCatadi = await ethers.getContractFactory('NinjaCatadi');
   const NinjaCatadiInstance = await NinjaCatadi.deploy();
   await NinjaCatadiInstance.renounceOwnership();

   //Deploy Catadi
   console.log();
   console.log(":: DEPLOY NINJACATALYST");
   const NinjaCatalyst = await ethers.getContractFactory('NinjaCatalyst');
   const NinjaCatalystInstance = await NinjaCatalyst.deploy();
   await NinjaCatalystInstance.mint(1000000000);


   console.log(`NinjaCatadi deployed to :    ${NinjaCatadiInstance.address}`);
   console.log(`NinjaCatalyst deployed to :  ${NinjaCatalystInstance.address}`);


}

deploy()
   .then(() => process.exit(0))
   .catch((error) => {
      console.error(error);
      process.exit(1);
   });
