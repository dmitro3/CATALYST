/**
 * @type import('hardhat/config').HardhatUserConfig
 */

require('@nomiclabs/hardhat-ethers');


const privateKey = '';

module.exports = {
   defaultNetwork: 'hardhat',

   networks: {
      hardhat: {},
      mainnet: {
         url: 'https://api.s0.t.hmny.io',
         accounts: [privateKey],
         chainId: 1666600000,
         network_id: '1666600000',
      },
      testnet: {
         url: 'https://api.s0.b.hmny.io',
         accounts: [privateKey],
         chainId: 1666700000,
         network_id: '1666700000',
      },
      mantleTestnet: {
         url: 'https://rpc.testnet.mantle.xyz',
         accounts: [privateKey],
         chainId: 5001,
         network_id: '5001',
      },
      fireTestnet: {
         url: 'https://rpc-testnet.5ire.network',
         accounts: [privateKey],
         chainId: 997,
         network_id: '997',
      },
      ThunderCoreTestnet: {
         url: 'https://testnet-rpc.thundercore.com',
         accounts: [privateKey],
         chainId: 18,
         network_id: '18',
      }
   },
   solidity: {
      compilers: [
         {
            version: '0.8.18',
            settings: {
               optimizer: {
                  enabled: true,
                  runs: 200,
               },
            },
         },
         {
            version: '0.6.6',
            settings: {
               optimizer: {
                  enabled: true,
                  runs: 200,
               },
            },
         },
      ],
   },
   paths: {
      sources: './contracts',
      cache: './cache',
      artifacts: './artifacts',
   },
   mocha: {
      timeout: 20000,
   },
};
